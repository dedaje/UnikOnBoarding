using UnikOnBoarding.Infrastructure.Contract.Dto;

namespace UnikOnBoarding.Infrastructure.Contract
{
    public interface IUnikService
    {
        Task Create(ProjectCreateRequestDto dto);
        Task Edit(ProjectEditRequestDto dto);
        Task/*<ProjectDeleteRequestDto?>*/ Delete(int id);
        Task<ProjectQueryResultDto?> GetProject(string userId, int? projectId);
        Task<IEnumerable<ProjectQueryResultDto>?> GetAllUserProjects(string userId);
        Task<IEnumerable<ProjectQueryResultDto>?> GetAllEditProjects(int? projectId);

        Task AddUser(AddUserRequestDto dto);
        Task RemoveUser(string userId, int? projectId);

        Task DeleteTask(int taskId);
    }
}
