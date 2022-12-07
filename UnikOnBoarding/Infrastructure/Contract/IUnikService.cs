using UnikOnBoarding.Infrastructure.Contract.Dto;
using UnikOnBoarding.Infrastructure.Contract.Dto.Project;
using UnikOnBoarding.Infrastructure.Contract.Dto.Task;
using UnikOnBoarding.Infrastructure.Contract.Dto.User;

namespace UnikOnBoarding.Infrastructure.Contract
{
    public interface IUnikService
    {
        Task CreateProject(ProjectCreateWithUserRequestDto dto);
        Task EditProject(ProjectEditRequestDto dto);
        Task RemoveUserFromProject(string userId, int? projectId);
        //Task RemoveUserFromProject(ProjectRemoveUserRequestDto dto);
        Task DeleteProject(int projectId);
        //Task DeleteProject(ProjectDeleteRequestDto dto);
        Task<ProjectQueryResultDto?> GetProject(int? projectId);
        Task<IEnumerable<ProjectUsersQueryResultDto>?> GetAllUserProjects(int? projectId, int? usersId); 
        Task<IEnumerable<ProjectQueryResultDto>?> GetAllProjects();

        Task CreateUser(AddUserRequestDto dto);
        Task<UserQueryResultDto> GetUser(string userId);
        Task<IEnumerable<UserQueryResultDto>?> GetAllUsers();


        Task CreateTask(TaskCreateRequestDto dto);
        Task EditTask(TaskEditRequestDto dto);
        Task DeleteTask(int id);
        Task<TaskQueryResultDto?> GetTask(int taskId);
        Task<IEnumerable<TaskQueryResultDto>?> GetAllTasksByRole(int projectId, int roleId);
        Task<IEnumerable<TaskQueryResultDto>?> GetAllTasksByUser(int projectId, string userId);
    }
}
