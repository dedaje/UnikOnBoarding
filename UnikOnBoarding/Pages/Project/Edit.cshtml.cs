using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnikOnBoarding.Infrastructure.Contract;
using UnikOnBoarding.Infrastructure.Contract.Dto.Project;

namespace UnikOnBoarding.Pages.Project
{
    public class EditModel : PageModel
    {
        private readonly IProjectService _projectService;

        public EditModel(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [BindProperty] public ProjectEditViewModel ProjectEditModel { get; set; }

        public async Task<IActionResult> OnGet(int? projectId)
        {
            if (projectId == null) return NotFound();

            var dto = await _projectService.GetProject(projectId);

            if (dto == null) return NotFound();

            ProjectEditModel = new ProjectEditViewModel
            {
                Id = dto.Id,
                ProjectName = dto.ProjectName,
                DateCreated = dto.DateCreated,
                RowVersion = dto.RowVersion,
            };

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();

            try
            {
                await _projectService.EditProject(new ProjectEditRequestDto
                {
                    Id = ProjectEditModel.Id,
                    ProjectName = ProjectEditModel.ProjectName,
                    DateCreated = ProjectEditModel.DateCreated,
                    RowVersion = ProjectEditModel.RowVersion,
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
