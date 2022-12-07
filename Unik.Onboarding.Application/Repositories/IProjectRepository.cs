using Unik.Onboarding.Application.Queries.Project;
using Unik.Onboarding.Domain.Model;

namespace Unik.Onboarding.Application.Repositories;

public interface IProjectRepository
{
    void CreateWithInitialUser(UsersEntity initialUserId, ProjectEntity project);
    IEnumerable<ProjectUsersQueryResultDto> GetAllUserProjects(int? projectId, int? usersId); //TODO: Hører den til her?
    IEnumerable<ProjectQueryResultDto> GetAllProjects();
    ProjectQueryResultDto GetProject(int projectId);
    ProjectEntity LoadProject(int projectId);
    void UpdateProject(ProjectEntity model);
    void RemoveUserFromProject(UsersEntity userId, ProjectEntity projectId);
    void DeleteProject(ProjectEntity model);
}