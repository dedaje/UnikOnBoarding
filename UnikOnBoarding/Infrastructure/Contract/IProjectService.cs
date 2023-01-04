using UnikOnBoarding.Infrastructure.Contract.Dto.Project;
using UnikOnBoarding.Infrastructure.Contract.Dto.ProjectUsers;

namespace UnikOnBoarding.Infrastructure.Contract
{
    public interface IProjectService
    {
        Task CreateProject(ProjectCreateWithUserRequestDto dto);
        Task<IEnumerable<ProjectQueryResultDto>?> GetAllProjects();
        Task<ProjectQueryResultDto?> GetProject(int? projectId);
        Task EditProject(ProjectEditRequestDto dto);
        Task DeleteProject(int projectId);
    }
}
