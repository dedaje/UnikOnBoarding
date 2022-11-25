using UnikOnBoarding.Infrastructure.Contract.Dto;

namespace UnikOnBoarding.Infrastructure.Contract
{
    public interface IUnikService
    {
        Task Create(ProjectCreateRequestDto dto);
        Task Edit(ProjectEditRequestDto dto);
        Task<ProjectQueryResultDto?> GetProject(string userId, int projectId);
        Task<IEnumerable<ProjectQueryResultDto>?> GetAllProjects(string userId);
    }
}
