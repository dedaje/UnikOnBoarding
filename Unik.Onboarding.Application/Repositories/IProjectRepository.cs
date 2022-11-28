using Unik.Onboarding.Application.Queries.Project;
using Unik.Onboarding.Domain.Model;

namespace Unik.Onboarding.Application.Repositories;

public interface IProjectRepository
{
    void Add(ProjectEntity project);
    IEnumerable<ProjectQueryResultDto> GetAllUserProjects(string userId);
    IEnumerable<ProjectQueryResultDto> GetAllEditProjects(int? projectId);
    ProjectQueryResultDto GetProject(string userId, int projectId);
    ProjectEntity Load(int projectId);
    void Update(ProjectEntity model);
}