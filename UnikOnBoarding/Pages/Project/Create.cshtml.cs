using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Unik.SqlServerContext;
using UnikOnBoarding.Infrastructure.Contract;
using UnikOnBoarding.Infrastructure.Contract.Dto;

namespace UnikOnBoarding.Pages.Project;

public class CreateModel : PageModel
{
    private readonly UnikDbContext _db;
    private readonly IUnikService _unikService;

    public CreateModel(IUnikService unikService, UnikDbContext db)
    {
        _unikService = unikService;
        _db = db;
    }

    [BindProperty] public ProjectCreateViewModel ProjectModel { get; set; } = new();

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPost()
    {
        ProjectModel.ProjectId = _db.ProjectEntities.Max(p => p.ProjectId) + 1;

        if (!ModelState.IsValid || !string.IsNullOrEmpty(ProjectModel.ProjectName) || !ProjectModel.ProjectId.HasValue) return Page();

        var dto = new ProjectCreateRequestDto
        {
            ProjectId = ProjectModel.ProjectId.Value,
            ProjectName = ProjectModel.ProjectName,
            UserId = User.Identity?.Name ?? string.Empty
        };

        try
        {
            await _unikService.Create(dto);
        }
        catch (Exception e)
        {
            ModelState.AddModelError(string.Empty, e.Message);
            return Page();
        }

        return new RedirectToPageResult("/Project/Index");
    }
}