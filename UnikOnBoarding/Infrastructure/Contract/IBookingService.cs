using UnikOnBoarding.Infrastructure.Contract.Dto.Booking;

namespace UnikOnBoarding.Infrastructure.Contract;

public interface IBookingService
{
    Task CreateBooking(BookingCreateRequestDto dto);
    Task<IEnumerable<BookingQueryResultDto>?> GetAllBookings();
    Task<BookingQueryResultDto> GetBooking(int? id);
    Task EditBooking(BookingEditRequestDto dto);
    Task DeleteBooking(int id);
}