using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnikOnBoarding.Infrastructure.Contract;
using UnikOnBoarding.Infrastructure.Contract.Dto;

namespace UnikOnBoarding.Pages.Onboarding
{
    public class EditModel : PageModel
    {
        private readonly IUnikService _unikService;

        public EditModel(IUnikService unikService)
        {
            _unikService = unikService;
        }

        [BindProperty] public ProjectEditViewModel ProjectModel { get; set; }

        public async Task<IActionResult> OnGet(int? projectId)
        {
            if (projectId == null) return NotFound();

            var dto = await _unikService.GetProject(User.Identity?.Name ?? string.Empty, projectId.Value);

            if (dto == null) return NotFound();

            ProjectModel = new ProjectEditViewModel
            {
                Id = dto.Id,
                ProjectId = dto.ProjectId,
                ProjectName = dto.ProjectName,
                DateAdded = dto.DateAdded,
                RowVersion = dto.RowVersion,
            };

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();


            try
            {
                await _unikService.Edit(new ProjectEditRequestDto
                {
                    Id = ProjectModel.Id,
                    ProjectId = ProjectModel.ProjectId,
                    ProjectName = ProjectModel.ProjectName,
                    DateAdded = ProjectModel.DateAdded,
                    UserId = User.Identity?.Name ?? string.Empty,
                    RowVersion = ProjectModel.RowVersion,
                });
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
