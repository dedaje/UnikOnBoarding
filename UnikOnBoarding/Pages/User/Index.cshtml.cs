using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnikOnBoarding.Infrastructure.Contract;

namespace UnikOnBoarding.Pages.User
{
    public class IndexModel : PageModel
    {
        private readonly IUnikService _unikService;

        public IndexModel(IUnikService unikService)
        {
            _unikService = unikService;
        }

        [BindProperty] public List<ProjectUsersIndexViewModel> ProjectUsersModel { get; set; } = new();
        [BindProperty] public int? _projectId { get; set; }
        [BindProperty] public string? _projectName { get; set; }

        public async Task OnGet(int? projectId, string? projectName)
        {
            var projectUsers = await _unikService.
            //_projectId = projectId;
            //_projectName = projectName;

            //var businessModel = await _unikService.GetAllUserProjects(_projectId);

            //if (businessModel == null) return;

            //businessModel?.ToList().ForEach(dto => UserModel.Add(new UserViewModel
            //{
            //    Id = dto.Id,
            //    ProjectId = dto.ProjectId,
            //    ProjectName = dto.ProjectName,
            //    DateAdded = dto.DateAdded,
            //    UserId = dto.UserId,
            //    RowVersion = dto.RowVersion,
            //}));
            throw new NotImplementedException();
        }
    }
}
