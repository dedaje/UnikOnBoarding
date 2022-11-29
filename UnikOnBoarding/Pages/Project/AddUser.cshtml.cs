using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnikOnBoarding.Infrastructure.Contract;
using UnikOnBoarding.Infrastructure.Contract.Dto;

namespace UnikOnBoarding.Pages.Project
{
    public class AddUserModel : PageModel
    {
        private readonly IUnikService _unikService;

        public AddUserModel(IUnikService unikService)
        {
            _unikService = unikService;
        }

        [BindProperty] public AddUserViewModel AddUserModel { get; set; }

        public async Task<IActionResult> OnGet(int projectId)
        {
            //if (projectId == null) return NotFound();

            var dto = await _unikService.GetProject(User.Identity?.Name ?? string.Empty, projectId);

            if (dto == null) return NotFound();

            AddUserModel = new AddUserViewModel
            {
                Id = dto.Id,
                ProjectId = dto.ProjectId,
                ProjectName = dto.ProjectName,
                UserId = dto.UserId,
            };

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();

            try
            {
                await _unikService.AddUser(new AddUserRequestDto
                {
                    ProjectId = AddUserModel.ProjectId,
                    ProjectName = AddUserModel.ProjectName,
                    UserId = AddUserModel.UserId,
                });
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
