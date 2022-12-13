using System.ComponentModel.DataAnnotations;
using Unik.Onboarding.Domain.DomainServices;

namespace Unik.Onboarding.Domain.Model;

public class BookingEntity
{
    private readonly IBookingDomainService _domainService;

    // For Entity Framework only!!!
    internal BookingEntity()
    {
    }

    public BookingEntity(int id, DateTime date, string userId)
    {
        Id = id;
        Date = date;
        UserId = userId;
    }

    public BookingEntity(IBookingDomainService domainService, DateTime date, string userId)
    {
        _domainService = domainService;
        Date = date;
        UserId = userId;

        if (_domainService.BookingDateIsTaken(Date.Date)) throw new ArgumentException("Der er allerede en booking på den dato");
    }

    public int Id { get; private set; } // PK
    public DateTime Date { get; private set; }
    //public bool IsBooked { get; private set; }
    public string UserId { get; private set; }
    [Timestamp]
    public byte[] RowVersion { get; private set; }

    public void Edit(DateTime date, string userId, byte[] rowVersion)
    {
        Date = date;
        UserId = userId;
        RowVersion = rowVersion;
    }
}