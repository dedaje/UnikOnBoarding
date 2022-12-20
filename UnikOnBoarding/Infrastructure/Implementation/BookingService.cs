using UnikOnBoarding.Infrastructure.Contract;
using UnikOnBoarding.Infrastructure.Contract.Dto.Booking;

namespace UnikOnBoarding.Infrastructure.Implementation
{
    public class BookingService : IBookingService
    {
        private readonly HttpClient _httpClient;

        public BookingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        async Task IBookingService.CreateBooking(BookingCreateRequestDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/Booking/CreateBooking", dto);

            if (response.IsSuccessStatusCode) return;

            var message = await response.Content.ReadAsStringAsync();
            throw new Exception(message);
        }

        async Task<IEnumerable<BookingQueryResultDto>?> IBookingService.GetAllBookings()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<BookingQueryResultDto>>($"api/Booking/AllBookings");
        }

        async Task<BookingQueryResultDto> IBookingService.GetBooking(int? id)
        {
            return await _httpClient.GetFromJsonAsync<BookingQueryResultDto>($"api/Booking/{id}/");
        }

        async Task IBookingService.EditBooking(BookingEditRequestDto dto)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Booking/EditBooking", dto);

            if (response.IsSuccessStatusCode) return;

            var message = await response.Content.ReadAsStringAsync();
            throw new Exception(message);
        }

        async Task IBookingService.DeleteBooking(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Booking/DeleteBooking/{id}/");

            if (response.IsSuccessStatusCode) return;

            var message = await response.Content.ReadAsStringAsync();
            throw new Exception(message);
        }
    }
}
