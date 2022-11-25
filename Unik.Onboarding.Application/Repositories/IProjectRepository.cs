using Unik.Onboarding.Application.Queries.Onboarding;
using Unik.Onboarding.Domain.Model;

namespace Unik.Onboarding.Application.Repositories;

public interface IProjectRepository
{
    void Add(ProjectEntity project);
    IEnumerable<ProjectQueryResultDto> GetAllProjects(string userId);
    ProjectQueryResultDto GetProject(string userId, int projectId);
    ProjectEntity Load(int projectId);
    void Update(ProjectEntity model);
}