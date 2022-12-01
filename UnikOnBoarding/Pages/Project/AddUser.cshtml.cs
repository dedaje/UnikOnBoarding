using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis;
using Unik.SqlServerContext;
using UnikOnBoarding.Infrastructure.Contract;
using UnikOnBoarding.Infrastructure.Contract.Dto;

namespace UnikOnBoarding.Pages.Project
{
    public class AddUserModel : PageModel
    {
        private readonly IUnikService _unikService;
        private readonly UnikDbContext _db;

        public AddUserModel(IUnikService unikService, UnikDbContext db)
        {
            _unikService = unikService;
            _db = db;
        }

        [BindProperty] public AddUserViewModel AddUserViewModel { get; set; } = new();
        //[BindProperty] public int _id { get; set; }

        public async Task<IActionResult> OnGet(int projectId)
        {
            //var model = _db.ProjectEntities.Find(id);
            //AddUserViewModel.Id = model.Id;
            //AddUserViewModel.ProjectId = model.ProjectId;
            //AddUserViewModel.ProjectName = model.ProjectName;
            if (projectId == null) return NotFound();

            var dto = await _unikService.GetProject(User.Identity?.Name ?? string.Empty, projectId);

            if (dto == null) return NotFound();

            AddUserViewModel.ProjectId = dto.ProjectId;
            AddUserViewModel.ProjectName = dto.ProjectName;

            //var model = new AddUserViewModel
            //{
            //    Id = dto.Id,
            //    ProjectId = dto.ProjectId,
            //    ProjectName = dto.ProjectName,
            //    UserId = dto.UserId,
            //};

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            //var dto = await _unikService.GetProject(User.Identity?.Name ?? string.Empty, AddUserViewModel.ProjectId);
            //if (dto == null) return NotFound();

            //var dto = new AddUserViewModel
            //{
            //    //Id = dto.Id,
            //    ProjectId = dto.ProjectId,
            //    ProjectName = dto.ProjectName,
            //    UserId = AddUserViewModel.UserId,
            //};
            
            if (!ModelState.IsValid || !string.IsNullOrEmpty(AddUserViewModel.UserId)) return Page();

            try
            {
                await _unikService.AddUser(new AddUserRequestDto
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

            return new RedirectToPageResult("/Project/Index");
        }
    }
}
