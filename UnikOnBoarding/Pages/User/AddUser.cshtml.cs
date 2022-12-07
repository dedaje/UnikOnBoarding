using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis;
using UnikOnBoarding.Infrastructure.Contract;
using UnikOnBoarding.Infrastructure.Contract.Dto.User;

namespace UnikOnBoarding.Pages.User
{
    public class AddUserModel : PageModel
    {
        private readonly IUnikService _unikService;

        public AddUserModel(IUnikService unikService)
        {
            _unikService = unikService;
        }

        [BindProperty] public AddUserViewModel AddUserViewModel { get; set; } = new();

        public async Task<IActionResult> OnGet(int? projectId)
        {
            if (projectId == null) return NotFound();

            var dto = await _unikService.GetProject(projectId);

            if (dto == null) return NotFound();

            AddUserViewModel = new AddUserViewModel
            {
                ProjectId = dto.ProjectId,
                ProjectName = dto.ProjectName,
            };

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();

            try
            {
                await _unikService.CreateUser(new AddUserRequestDto
                {
                    ProjectId = AddUserViewModel.ProjectId,
                    ProjectName = AddUserViewModel.ProjectName,
                    UserId = AddUserViewModel.UserId,
                });
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return Page();
            }

            return new RedirectToPageResult("/User/Index", "/User/Index", AddUserViewModel);
        }
    }
}
