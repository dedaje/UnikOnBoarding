//using Unik.Onboarding.Application.Commands.Task;
using UnikOnBoarding.Infrastructure.Contract.Dto;

namespace UnikOnBoarding.Infrastructure.Contract
{
    public interface IUnikService
    {
        Task Create(ProjectCreateRequestDto dto);
        Task Edit(ProjectEditRequestDto dto);
        Task Delete(int id);
        Task<ProjectQueryResultDto?> GetProject(string userId, int? projectId);
        Task<IEnumerable<ProjectQueryResultDto>?> GetAllUserProjects(string userId);
        Task<IEnumerable<ProjectQueryResultDto>?> GetAllEditProjects(int? projectId);

        Task AddUser(AddUserRequestDto dto);
        Task RemoveUser(string userId, int? projectId);
        Task DeleteTask(int id);

        Task CreateTask(TaskCreateRequestDto dto);
        Task EditTask(TaskEditRequestDto dto);
        Task<TaskQueryResultDto?> GetTask(int taskId);
        Task<IEnumerable<TaskQueryResultDto>?> GetAllTasksByRole(int projectId, int roleId);
        Task<IEnumerable<TaskQueryResultDto>?> GetAllTasksByUser(int projectId, string userId);
    }
}
