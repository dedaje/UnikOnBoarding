using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnikOnBoarding.Infrastructure.Contract;

namespace UnikOnBoarding.Pages.Onboarding
{
    public class IndexModel : PageModel
    {
        private readonly IUnikService _unikService;

        public IndexModel(IUnikService unikService)
        {
            _unikService = unikService;
        }

        [BindProperty] public List<OnboardingIndexViewModel> IndexViewModel { get; set; } = new();

        public async Task OnGet()
        {
            var businessModel = await _unikService.GetAll(/*User.Identity?.Name ?? String.Empty*/);

            businessModel.ToList().ForEach(dto => IndexViewModel.Add(new OnboardingIndexViewModel { ProjectId = dto.ProjectId, Date = dto.Date , ProjectName = dto.ProjectName}));
        }
    }
}
