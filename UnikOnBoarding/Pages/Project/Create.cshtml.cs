using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnikOnBoarding.Infrastructure.Contract;
using UnikOnBoarding.Infrastructure.Contract.Dto.Project;
using UnikOnBoarding.Infrastructure.Contract.Dto.ProjectUsers;
using UnikOnBoarding.Infrastructure.Contract.Dto.User;
using UnikOnBoarding.Pages.User;

namespace UnikOnBoarding.Pages.Project;

public class CreateModel : PageModel
{
    private readonly IProjectService _projectService;
    private readonly IUserService _userService;

    public CreateModel(IProjectService projectService, IUserService userService)
    {
        _projectService = projectService;
        _userService = userService;
    }

    [BindProperty] public ProjectCreateWithUserViewModel ProjectWithUserModel { get; set; } = new();

    public async Task<IActionResult> OnGet()
    {
        var user = await _userService.GetUser(User.Identity?.Name ?? string.Empty);

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
            await _projectService.CreateProject(dto);
        }
        catch (Exception e)
        {
            ModelState.AddModelError(string.Empty, e.Message);
            return Page();
        }

        return new RedirectToPageResult("/Project/Index");
    }
}