using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnikOnBoarding.Infrastructure.Contract;
using UnikOnBoarding.Pages.Project;
using UnikOnBoarding.Pages.ProjectUsers;

namespace UnikOnBoarding.Pages.ProjectUsers
{
    public class RemoveUserModel : PageModel
    {
        private readonly IProjectService _projectService;
        private readonly IProjectUsersService _projectUsersService;

        public RemoveUserModel(IProjectService projectService, IProjectUsersService projectUsersService)
        {
            _projectService = projectService;
            _projectUsersService = projectUsersService;
        }

        [BindProperty] public RemoveUserViewModel RemoveViewModel { get; set; } = new();

        public /*async*/ Task<IActionResult> OnGet(string? userId, int? projectId)
        {
            //if (projectId == null || string.IsNullOrEmpty(userId)) return NotFound();

            //var dto = await _unikService.GetProject(projectId.Value);

            //if (dto == null) return NotFound();

            //RemoveViewModel = new RemoveUserViewModel
            //{
            //    Id = dto.Id,
            //    ProjectId = dto.ProjectId,
            //    ProjectName = dto.ProjectName,
            //    UserId = dto.UserId,
            //};

            //return Page();

            throw new NotImplementedException();
        }

        public /*async*/ Task<IActionResult> OnPost()
        {
            //var dto = await _unikService.GetProject(RemoveViewModel.UserId, RemoveViewModel.ProjectId);

            //RemoveViewModel = new RemoveUserViewModel
            //{
            //    Id = dto.Id,
            //    ProjectId = dto.ProjectId,
            //    ProjectName = dto.ProjectName,
            //    UserId = dto.UserId,
            //};

            //if (!ModelState.IsValid) return Page();

            //try
            //{
            //    await _unikService.RemoveUser(RemoveViewModel.UserId, RemoveViewModel.ProjectId);
            //}
            //catch (Exception e)
            //{
            //    ModelState.AddModelError(string.Empty, e.Message);
            //    return Page();
            //}

            //return new RedirectToPageResult("/User/Index", "/User/Index", RemoveViewModel);

            throw new NotImplementedException();
        }
    }
}
