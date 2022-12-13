using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnikOnBoarding.Infrastructure.Contract;
using UnikOnBoarding.Pages.Project;

namespace UnikOnBoarding.Pages.Booking
{
    public class IndexModel : PageModel
    {
        private readonly IUnikService _unikService;

        public IndexModel(IUnikService unikService)
        {
            _unikService = unikService;
        }

        [BindProperty] public List<BookingIndexViewModel> IndexViewModel { get; set; } = new();
        //private string _userId;

        public async Task OnGet()
        {
            var businessModel = await _unikService.GetAllBookings();

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
