using Unik.Onboarding.Application.Queries.Booking;
using Unik.Onboarding.Application.Repositories;

namespace Unik.Onboarding.Application.Queries.Implementation.Booking;

public class BookingGetAllQuery : IBookingGetAllQuery
{
    private readonly IBookingRepository _repository;

    public BookingGetAllQuery(IBookingRepository repository)
    {
        _repository = repository;
    }

    IEnumerable<BookingQueryResultDto> IBookingGetAllQuery.GetAllBookings()
    {
        return _repository.GetAllBookings();
    }
}