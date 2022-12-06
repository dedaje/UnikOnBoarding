using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnikOnBoarding.Infrastructure.Contract;
using UnikOnBoarding.Infrastructure.Contract.Dto;

namespace UnikOnBoarding.Pages.Tasks
{
    public class EditModel : PageModel
    {
        private readonly IUnikService _unikService;

        public EditModel(IUnikService unikService)
        {
            _unikService = unikService;
        }

        [BindProperty] public TaskEditViewModel TaskModel { get; set; } = new();

        public async Task<IActionResult> OnGet(int? taskId)
        {
            if (taskId == null) return NotFound();
            var dto = await _unikService.GetTask(taskId.Value);

            TaskModel = new TaskEditViewModel { TaskName = dto.TaskName, TaskDescription = dto.TaskDescription, TaskId = dto.TaskId, RowVersion = dto.RowVersion };

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();

            await _unikService.EditTask(new TaskEditRequestDto 
            {
                TaskId = TaskModel.TaskId,
                TaskName = TaskModel.TaskName, 
                TaskDescription = TaskModel.TaskDescription,
                DateCreated = TaskModel.DateCreated,
                ProjectId = TaskModel.ProjectId,
                RoleId = TaskModel.RoleId,
                UserId = User.Identity?.Name ?? String.Empty,
                RowVersion = TaskModel.RowVersion 
            });

            return RedirectToPage("./Index");
        }
    }
}
