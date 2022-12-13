using Unik.Onboarding.Application.Commands.Booking;
using Unik.Onboarding.Application.Repositories;

namespace Unik.Onboarding.Application.Commands.Implementation.Booking;

public class EditBookingCommand : IEditBookingCommand
{
    private readonly IBookingRepository _repository;

    public EditBookingCommand(IBookingRepository repository)
    {
        _repository = repository;
    }

    void IEditBookingCommand.Edit(BookingEditRequestDto request)
    {
        //Read
        var model = _repository.LoadBooking(request.Id);

        //DoIt
        model.Edit(request.Date, request.UserId, request.RowVersion);

        //Save
        _repository.UpdateBooking(model);
    }
}