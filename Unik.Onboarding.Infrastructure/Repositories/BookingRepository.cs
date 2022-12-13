using Microsoft.EntityFrameworkCore;
using Unik.Onboarding.Application.Queries.Booking;
using Unik.Onboarding.Application.Repositories;
using Unik.Onboarding.Domain.Model;
using Unik.SqlServerContext;

namespace Unik.Onboarding.Infrastructure.Repositories;

public class BookingRepository : IBookingRepository
{
    private readonly UnikDbContext _db;

    public BookingRepository(UnikDbContext db)
    {
        _db = db;
    }

    void IBookingRepository.CreateBooking(BookingEntity booking)
    {
        _db.Add(booking);
        _db.SaveChanges();
    }

    IEnumerable<BookingQueryResultDto> IBookingRepository.GetAllBookings()
    {
        foreach (var entity in _db.BookingEntities.AsNoTracking().ToList())
            yield return new BookingQueryResultDto
            {
                Id = entity.Id,
                Date = entity.Date,
                UserId = entity.UserId,
                RowVersion = entity.RowVersion
            };
    }

    BookingQueryResultDto IBookingRepository.GetBooking(int id)
    {
        var dbEntity = _db.BookingEntities.AsNoTracking().FirstOrDefault(a => a.Id == id);
        if (dbEntity == null) throw new Exception("Denne booking findes ikke");

        return new BookingQueryResultDto
        {
            Id = dbEntity.Id,
            Date = dbEntity.Date,
            UserId = dbEntity.UserId,
            RowVersion = dbEntity.RowVersion
        };
    }

    BookingEntity IBookingRepository.LoadBooking(int id)
    {
        var dbEntity = _db.BookingEntities.AsNoTracking().FirstOrDefault(a => a.Id == id);
        if (dbEntity == null) throw new Exception("Den booking findes ikke i databasen");

        return dbEntity;
    }

    void IBookingRepository.UpdateBooking(BookingEntity booking)
    {
        _db.Update(booking);
        _db.SaveChanges();
    }

    void IBookingRepository.DeleteBooking(BookingEntity booking)
    {
        _db.Remove(booking);
        _db.SaveChanges();
    }
}