using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis;
using Unik.WebApp.UserContext;
using UnikOnBoarding.Infrastructure.Contract;
using UnikOnBoarding.Infrastructure.Contract.Dto.User;

namespace UnikOnBoarding.Pages.User
{
    public class CreateModel : PageModel
    {
        private readonly IUnikService _unikService;
        private readonly WebAppUserDbContext _userDbContext;

        public CreateModel(IUnikService unikService, WebAppUserDbContext userDbContext)
        {
            _unikService = unikService;
            _userDbContext = userDbContext;
        }

        [BindProperty] public CreateUserViewModel CreateUserModel { get; set; } = new();

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            //
            if (!ModelState.IsValid) return Page();

            var dto = new UserCreateRequestDto
                { UserId = CreateUserModel.UserId };

            try
            {
                await _unikService.CreateUser(dto);
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return Page();
            }

            return new RedirectToPageResult("/User/Index"/*, "/User/Index", CreateUserModel*/);
        }
    }
}
