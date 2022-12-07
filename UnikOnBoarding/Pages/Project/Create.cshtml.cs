using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Unik.SqlServerContext;
using UnikOnBoarding.Infrastructure.Contract;
using UnikOnBoarding.Infrastructure.Contract.Dto;
using UnikOnBoarding.Infrastructure.Contract.Dto.Project;
using UnikOnBoarding.Infrastructure.Contract.Dto.User;
using UnikOnBoarding.Pages.User;

namespace UnikOnBoarding.Pages.Project;

public class CreateModel : PageModel
{
    private readonly IUnikService _unikService;

    public CreateModel(IUnikService unikService)
    {
        _unikService = unikService;
    }

    [BindProperty] public ProjectCreateWithUserViewModel ProjectWithUserModel { get; set; } = new();

    public async Task<IActionResult> OnGet()
    {
        var user = await _unikService.GetUser(User.Identity?.Name ?? string.Empty);

        if (user == null) return NotFound();

        ProjectWithUserModel.UserModel = new UserIndexViewModel
        {
            Id = user.Id,
            UserId = user.UserId,
            RowVersion = user.RowVersion,
        };

        return Page();
    }

    public async Task<IActionResult> OnPost()
    {
        if (!ModelState.IsValid) return Page();

        var dto = new ProjectCreateWithUserRequestDto
        {
            ProjectCreateDto = new ProjectCreateRequestDto
                {ProjectName = ProjectWithUserModel.ProjectCreateModel.ProjectName},
            UserQueryDto = new UserQueryResultDto 
                {Id = ProjectWithUserModel.UserModel.Id, UserId = ProjectWithUserModel.UserModel.UserId, RowVersion = ProjectWithUserModel.UserModel.RowVersion}
        };

        try
        {
            await _unikService.CreateProject(dto);
        }
        catch (Exception e)
        {
            ModelState.AddModelError(string.Empty, e.Message);
            return Page();
        }

        return new RedirectToPageResult("/Project/Index");
    }
}