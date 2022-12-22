using WebClient.UnikOnBoarding.Infrastructure.Contract.Dto.Task;

namespace WebClient.UnikOnBoarding.Infrastructure.Contract;

public interface ITaskService
{
    Task CreateTask(TaskCreateRequestDto dto);
    Task<IEnumerable<TaskQueryResultDto>?> GetAllTasks(int projectId);
    Task<TaskQueryResultDto?> GetTask(int taskId);
    Task EditTask(TaskEditRequestDto dto);
    Task DeleteTask(int id);
}