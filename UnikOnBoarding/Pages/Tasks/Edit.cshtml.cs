using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnikOnBoarding.Infrastructure.Contract;
using UnikOnBoarding.Infrastructure.Contract.Dto;

namespace UnikOnBoarding.Pages.Tasks
{
    public class EditModel : PageModel
    {
        private readonly ITaskService _taskService;

        public EditModel(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [BindProperty] public TaskEditViewModel TaskModel { get; set; } = new();

        public /*async*/ Task<IActionResult> OnGet(int? taskId)
        {
            //if (taskId == null) return NotFound();
            //var dto = await _unikService.GetTask(taskId.Value);

            //TaskModel = new TaskEditViewModel 
            //{
            //    TaskId = dto.TaskId,
            //    TaskName = dto.TaskName, 
            //    TaskDescription = dto.TaskDescription, 
            //    DateCreated = dto.DateCreated,
            //    ProjectId = dto.ProjectId,
            //    RoleId = dto.RoleId,
            //    UserId = User.Identity?.Name ?? String.Empty
            //};

            //return Page();

            throw new NotImplementedException();
        }

        public /*async*/ Task<IActionResult> OnPost()
        {
            
            //if (!ModelState.IsValid) return Page();

            //try
            //{
            //    await _unikService.EditTask(new TaskEditRequestDto
            //    {
            //        TaskId = TaskModel.TaskId,
            //        TaskName = TaskModel.TaskName,
            //        TaskDescription = TaskModel.TaskDescription,
            //        DateCreated = TaskModel.DateCreated,
            //        ProjectId = TaskModel.ProjectId,
            //        RoleId = TaskModel.RoleId,
            //        UserId = TaskModel.UserId
            //        //RowVersion = TaskModel.RowVersion
            //    });
            //}
            //catch(Exception e) 
            //{
            //    ModelState.AddModelError(string.Empty, e.Message);
            //    return Page();
            //}

            //return RedirectToPage("../Project/Index");

            throw new NotImplementedException();
        }
    }
}
