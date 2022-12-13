using Microsoft.EntityFrameworkCore;
using Unik.Onboarding.Domain.DomainServices;
using Unik.SqlServerContext;

namespace Unik.Onboarding.Infrastructure.DomainServices;

public class BookingDomainService : IBookingDomainService
{
    private readonly UnikDbContext _db;

    public BookingDomainService(UnikDbContext db)
    {
        _db = db;
    }

    bool IBookingDomainService.BookingDateIsTaken(DateTime date)
    {
        return _db.BookingEntities.AsNoTracking().ToList().Any(b => b.Date.Date == date.Date);
    }
}