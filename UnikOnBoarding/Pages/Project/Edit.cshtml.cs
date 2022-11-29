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

            //if (dto == null) return NotFound();

            //ProjectModel = new ProjectEditViewModel
            //{
            //    //Id = dto.Id,
            //    ProjectId = dto.ProjectId,
            //    ProjectName = dto.ProjectName,
            //    //DateAdded = dto.DateAdded,
            //    RowVersion = dto.RowVersion,
            //};

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            var dto = await _unikService.GetAllEditProjects(_projectId);

            dto.ToList().ForEach(dt => ProjectModel.Add(new ProjectEditViewModel
            {
                ProjectId = dt.ProjectId,
                ProjectName = _ProjectName,
                //RowVersion = dt.RowVersion,
            }));

            if (!ModelState.IsValid) return Page();

            // Lav liste over alle projekter med et bestemt ProjektId? Vil alle felter blive ændret eller kun den første den finder?

            foreach (var item in ProjectModel)
            {
                try
                {
                    await _unikService.Edit(new ProjectEditRequestDto
                    {
                        //Id = ProjectModel.Id,
                        ProjectId = item.ProjectId,
                        ProjectName = item.ProjectName,
                        //DateAdded = ProjectModel.DateAdded,
                        //UserId = User.Identity?.Name ?? string.Empty,
                        //RowVersion = item.RowVersion
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
