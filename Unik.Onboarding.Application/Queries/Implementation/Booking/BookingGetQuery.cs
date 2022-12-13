using Unik.Onboarding.Application.Queries.Booking;
using Unik.Onboarding.Application.Repositories;

namespace Unik.Onboarding.Application.Queries.Implementation.Booking;

public class BookingGetQuery : IBookingGetQuery
{
    private readonly IBookingRepository _repository;

    public BookingGetQuery(IBookingRepository repository)
    {
        _repository = repository;
    }

    BookingQueryResultDto IBookingGetQuery.GetBooking(int id)
    {
        return _repository.GetBooking(id);
    }
}