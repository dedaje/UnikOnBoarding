namespace Unik.Onboarding.Application.Queries.Booking;

public interface IBookingGetQuery
{
    BookingQueryResultDto GetBooking(int id);
}