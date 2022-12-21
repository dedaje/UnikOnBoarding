using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis;
using System.Drawing.Printing;
using UnikOnBoarding.Infrastructure.Contract;
using UnikOnBoarding.Infrastructure.Contract.Dto;


namespace UnikOnBoarding.Pages.Tasks
{
    public class CreateModel : PageModel
    {
        private readonly ITaskService _taskService;
        private readonly IUserService _userService;

        public CreateModel(ITaskService taskService, IUserService userService)
        {
            _taskService = taskService;
            _userService = userService;
        }
        
        [BindProperty] public TaskCreateViewModel TaskModel { get; set; } = new();

        public void OnGet(int? projectId)
        {
            //if (projectId == null) NotFound();

            //TaskModel = new TaskCreateViewModel
            //{
            //    ProjectId = projectId,
            //    UserId = User.Identity?.Name ?? string.Empty
            //};

            throw new NotImplementedException();
        }

        public /*async*/ Task<IActionResult> OnPost()
        {
           
           //if (!ModelState.IsValid) return Page();

           // var dto = new TaskCreateRequestDto
           // {
               
           //     TaskName = TaskModel.TaskName,
           //     TaskDescription = TaskModel.TaskDescription,
           //     ProjectId = TaskModel.ProjectId,
           //     RoleId = TaskModel.RoleId,
           //     UserId = TaskModel.UserId

           // };

           // try
           // {
           //     await _unikService.CreateTask(dto);
           // }
           // catch (Exception e)
           // {
           //     ModelState.AddModelError(string.Empty, e.Message);
           //     return Page();
           // }

           // return new RedirectToPageResult("/Tasks/Index", "/Tasks/Index", TaskModel);

           throw new NotImplementedException();
        }
    }
}
