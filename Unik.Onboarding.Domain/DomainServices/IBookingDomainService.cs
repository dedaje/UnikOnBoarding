namespace Unik.Onboarding.Domain.DomainServices;

public interface IBookingDomainService
{
    bool BookingDateIsTaken(DateTime date);
}