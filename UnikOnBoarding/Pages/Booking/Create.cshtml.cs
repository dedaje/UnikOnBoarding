using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using UnikOnBoarding.Infrastructure.Contract;
using UnikOnBoarding.Infrastructure.Contract.Dto.Booking;

namespace UnikOnBoarding.Pages.Booking
{
    public class CreateModel : PageModel
    {
        private readonly IBookingService _bookingService;

        public CreateModel(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [BindProperty] public BookingCreateViewModel CreateViewModel { get; set; } = new();
        [BindProperty, DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
        public DateTime? DateTime { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        { 
            CreateViewModel.Date = DateTime;
            CreateViewModel.UserId = User.Identity?.Name ?? string.Empty;

            if (!ModelState.IsValid) return Page();

            var dto = new BookingCreateRequestDto
            {
                Date = CreateViewModel.Date,
                UserId = CreateViewModel.UserId,
            };

            try
            {
                await _bookingService.CreateBooking(dto);
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return Page();
            }

            return new RedirectToPageResult("/Booking/Index");
        }
    }
}
