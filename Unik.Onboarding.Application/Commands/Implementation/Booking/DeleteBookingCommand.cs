using Unik.Onboarding.Application.Commands.Booking;
using Unik.Onboarding.Application.Repositories;

namespace Unik.Onboarding.Application.Commands.Implementation.Booking;

public class DeleteBookingCommand : IDeleteBookingCommand
{
    private readonly IBookingRepository _repository;

    public DeleteBookingCommand(IBookingRepository repository)
    {
        _repository = repository;
    }

    void IDeleteBookingCommand.Delete(int id)
    {
        var model = _repository.LoadBooking(id);

        _repository.DeleteBooking(model);
    }
}