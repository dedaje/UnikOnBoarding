namespace Unik.Onboarding.Application.Queries.Booking;

public interface IBookingGetAllQuery
{
    IEnumerable<BookingQueryResultDto> GetAllBookings();
}