using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnikOnBoarding.Infrastructure.Contract;

namespace UnikOnBoarding.Pages.Project
{
    public class DeleteModel : PageModel
    {
        private readonly IUnikService _unikService;

        public DeleteModel(IUnikService unikService)
        {
            _unikService = unikService;
        }

        [BindProperty] public List<ProjectDeleteViewModel> ProjectDeleteModel { get; set; } = new();
        [BindProperty] public ProjectDeleteViewModel DeleteViewModel { get; set; } = new();
        //[BindProperty] public int? _projectId { get; set; }
        //[BindProperty] public string _ProjectName { get; set; }

        public async Task<IActionResult> OnGet(int? projectId)
        {
            if (projectId == null) return NotFound();

            //_projectId = projectId;

            var dto = await _unikService.GetProject(User.Identity?.Name ?? string.Empty, projectId.Value);

            if (dto == null) return NotFound();

            DeleteViewModel = new ProjectDeleteViewModel
            {
                Id = dto.Id,
                ProjectId = dto.ProjectId,
                ProjectName = dto.ProjectName,
            };

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            var dto = await _unikService.GetAllEditProjects(DeleteViewModel.ProjectId);

            dto?.ToList().ForEach(dt => ProjectDeleteModel.Add(new ProjectDeleteViewModel
            {
                Id = dt.Id,
                ProjectId = dt.ProjectId,
                ProjectName = dt.ProjectName,
            }));

            if (!ModelState.IsValid) return Page();

            foreach (var item in ProjectDeleteModel)
            {
                try
                {
                    await _unikService.Delete(item.Id);
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
