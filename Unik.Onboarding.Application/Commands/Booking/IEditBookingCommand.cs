namespace Unik.Onboarding.Application.Commands.Booking;

public interface IEditBookingCommand
{
    void Edit(BookingEditRequestDto request);
}