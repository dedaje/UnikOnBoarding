using System.Data;
using Unik.Crosscut.TransactionHandling;
using Unik.Onboarding.Application.Commands.Booking;
using Unik.Onboarding.Application.Repositories;
using Unik.Onboarding.Domain.DomainServices;
using Unik.Onboarding.Domain.Model;

namespace Unik.Onboarding.Application.Commands.Implementation.Booking;

public class CreateBookingCommand : ICreateBookingCommand
{
    private readonly IBookingRepository _repository;
    private readonly IBookingDomainService _domainService;
    private readonly IUnitOfWork _uow;

    public CreateBookingCommand(IBookingRepository repository, IBookingDomainService domainService, IUnitOfWork uow)
    {
        _repository = repository;
        _domainService = domainService;
        _uow = uow;
    }

    void ICreateBookingCommand.Create(BookingCreateRequestDto request)
    {
        try
        {
            _uow.BeginTransaction(IsolationLevel.Serializable);

            var booking = new BookingEntity(_domainService, request.Date, request.UserId);
            _repository.CreateBooking(booking);

            _uow.Commit();
        }
        catch
        {
            _uow.Rollback();
            throw;
        }
        
    }
}