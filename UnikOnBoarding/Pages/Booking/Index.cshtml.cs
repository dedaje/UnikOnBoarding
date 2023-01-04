using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnikOnBoarding.Infrastructure.Contract;

namespace UnikOnBoarding.Pages.Booking
{
    public class IndexModel : PageModel
    {
        private readonly IBookingService _bookingService;

        public IndexModel(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [BindProperty] public List<BookingIndexViewModel> IndexViewModel { get; set; } = new();

        public async Task OnGet()
        {
            var businessModel = await _bookingService.GetAllBookings();

            //_userId = _unikService.GetUser(User.Identity?.Name ?? string.Empty).Result.UserId;

            if (businessModel == null) NotFound();

            businessModel?.ToList().ForEach(dto => IndexViewModel.Add(new BookingIndexViewModel
            {
                Id = dto.Id,
                Date = dto.Date,
                UserId = dto.UserId,
                RowVersion = dto.RowVersion,
            }));
        }
    }
}
