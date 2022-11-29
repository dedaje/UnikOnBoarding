using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnikOnBoarding.Infrastructure.Contract;
using UnikOnBoarding.Infrastructure.Contract.Dto;

namespace UnikOnBoarding.Pages.Project
{
    public class EditModel : PageModel
    {
        private readonly IUnikService _unikService;

        public EditModel(IUnikService unikService)
        {
            _unikService = unikService;
        }

        [BindProperty] public List<ProjectEditViewModel> ProjectModel { get; set; }
        [BindProperty] public int? _projectId { get; set; }
        [BindProperty] public string _ProjectName { get; set; }

        public async Task<IActionResult> OnGet(int? projectId)
        {
            if (projectId == null) return NotFound();
            
            _projectId = projectId;

            var dto = await _unikService.GetProject(User.Identity?.Name ?? string.Empty, projectId.Value);

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            var dto = await _unikService.GetAllEditProjects(_projectId);

            dto.ToList().ForEach(dt => ProjectModel.Add(new ProjectEditViewModel
            {
                Id = dt.Id,
                ProjectId = dt.ProjectId,
                ProjectName = _ProjectName,
            }));

            if (!ModelState.IsValid) return Page();

            foreach (var item in ProjectModel)
            {
                try
                {
                    await _unikService.Edit(new ProjectEditRequestDto
                    {
                        Id = item.Id,
                        ProjectId = item.ProjectId,
                        ProjectName = item.ProjectName,
                    });
                }
                catch (Exception e)
                {
                    ModelState.AddModelError(string.Empty, e.Message);
                    return Page();
                }
            }

            return RedirectToPage("./Index");
        }
    }
}
