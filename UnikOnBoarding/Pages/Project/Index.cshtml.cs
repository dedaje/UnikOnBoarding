using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnikOnBoarding.Infrastructure.Contract;

namespace UnikOnBoarding.Pages.Project
{
    public class IndexModel : PageModel
    {
        private readonly IUnikService _unikService;

        public IndexModel(IUnikService unikService)
        {
            _unikService = unikService;
        }

        [BindProperty] public List<ProjectIndexViewModel> IndexViewModel { get; set; } = new();

        public async Task OnGet()
        {
            var businessModel = await _unikService.GetAllUserProjects(User.Identity?.Name ?? string.Empty); // User.Identity?.Name ?? String.Empty*

            if (businessModel == null) return;

            businessModel?.ToList().ForEach(dto => IndexViewModel.Add(new ProjectIndexViewModel
            {
                Id = dto.Id,
                ProjectId = dto.ProjectId,
                DateAdded = dto.DateAdded,
                ProjectName = dto.ProjectName,
                UserId = dto.UserId,
                RowVersion = dto.RowVersion,
            }));
        }
    }
}
