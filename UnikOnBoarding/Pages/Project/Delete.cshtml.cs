using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnikOnBoarding.Infrastructure.Contract;
using UnikOnBoarding.Infrastructure.Contract.Dto.Project;

namespace UnikOnBoarding.Pages.Project
{
    public class DeleteModel : PageModel
    {
        private readonly IUnikService _unikService;

        public DeleteModel(IUnikService unikService)
        {
            _unikService = unikService;
        }

        [BindProperty] public ProjectDeleteViewModel DeleteViewModel { get; set; } = new();

        public async Task<IActionResult> OnGet(int? projectId)
        {
            if (projectId == null) return NotFound();

            var dto = await _unikService.GetProject(projectId);

            if (dto == null) return NotFound();

            DeleteViewModel = new ProjectDeleteViewModel
            {
                Id = dto.Id,
                ProjectName = dto.ProjectName,
            };

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();

            try
            {
                await _unikService.DeleteProject(DeleteViewModel.Id);
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return Page();
            }

            return RedirectToPage("./Index");
            
            //throw new NotImplementedException();
        }
    }
}
