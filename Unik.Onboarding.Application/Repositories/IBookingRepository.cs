using Unik.Onboarding.Application.Queries.Booking;
using Unik.Onboarding.Domain.Model;

namespace Unik.Onboarding.Application.Repositories;

public interface IBookingRepository
{
    void CreateBooking(BookingEntity booking);
    IEnumerable<BookingQueryResultDto> GetAllBookings();
    BookingQueryResultDto GetBooking(int id);
    BookingEntity LoadBooking(int id);
    void UpdateBooking(BookingEntity booking);
    void DeleteBooking(BookingEntity booking);
}