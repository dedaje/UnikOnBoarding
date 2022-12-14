using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnikOnBoarding.Infrastructure.Contract;
using UnikOnBoarding.Infrastructure.Contract.Dto.Project;
using UnikOnBoarding.Infrastructure.Contract.Dto.ProjectUsers;
using UnikOnBoarding.Infrastructure.Contract.Dto.User;
using UnikOnBoarding.Pages.Project;
using UnikOnBoarding.Pages.User;

namespace UnikOnBoarding.Pages.ProjectUsers
{
    public class AddUserModel : PageModel
    {
        private readonly IProjectService _projectService;
        private readonly IProjectUsersService _projectUsersService;
        private readonly IUserService _userService;

        public AddUserModel(IProjectService projectService, IProjectUsersService projectUsersService, IUserService userService)
        {
            _projectService = projectService;
            _projectUsersService = projectUsersService;
            _userService = userService;
        }

        [BindProperty] public AddUserViewModel AddUser { get; set; } = new();

        public async Task<IActionResult> OnGet(int projectId)
        {
            var project = await _projectService.GetProject(projectId);

            if (project == null) return NotFound();

            AddUser.ProjectViewModel = new ProjectIndexViewModel
            {
                Id = project.Id, 
                ProjectName = project.ProjectName, 
                DateCreated = project.DateCreated, 
                RowVersion = project.RowVersion
            };

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            var user = await _userService.GetUser(AddUser.UserViewModel.UserId);

            if (user == null) return NotFound();

            AddUser.UserViewModel = new UserIndexViewModel
            {
                Id = user.Id, 
                UserId = user.UserId, 
                RowVersion = user.RowVersion
            };

            var dto = new ProjectAddUserRequestDto
            {
                ProjectQueryDto = new ProjectQueryResultDto
                {
                    Id = AddUser.ProjectViewModel.Id,
                    ProjectName = AddUser.ProjectViewModel.ProjectName,
                    DateCreated = AddUser.ProjectViewModel.DateCreated,
                    RowVersion = AddUser.ProjectViewModel.RowVersion,
                },

                UserQueryDto = new UserQueryResultDto
                {
                    Id = AddUser.UserViewModel.Id,
                    UserId = AddUser.UserViewModel.UserId,
                    RowVersion = AddUser.UserViewModel.RowVersion
                }
            };

            if (!ModelState.IsValid) return Page();

            try
            {
                await _projectUsersService.AddUserToProject(dto);
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return Page();
            }

            return new RedirectToPageResult("/Project/Index");
        }
    }
}
