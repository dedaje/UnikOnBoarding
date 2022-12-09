using Unik.Onboarding.Application.Queries.ProjectUsers;

namespace Unik.Onboarding.Application.Queries.Project;

public interface IProjectGetAllQuery
{
    IEnumerable<ProjectUsersQueryResultDto> GetAllUserProjects(int projectId, string userId); //Gets all the projects that the logged in user is assigned to
    //ProjectUsersQueryResultDto GetAllUserProjects(int projectId, int usersId); //Gets all the projects that the logged in user is assigned to
    IEnumerable<ProjectQueryResultDto> GetAllProjects();
}