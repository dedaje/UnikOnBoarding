namespace Unik.Onboarding.Application.Commands.Booking;

public interface ICreateBookingCommand
{
    void Create(BookingCreateRequestDto request);
}