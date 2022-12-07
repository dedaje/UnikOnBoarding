namespace Unik.Onboarding.Application.Queries.Project;

public interface IProjectGetAllQuery
{
    //Gets all the projects that the logged in user is assigned to
    IEnumerable<ProjectUsersQueryResultDto> GetAllUserProjects(int projectId, int usersId); // TODO: Hører den til her?
    IEnumerable<ProjectQueryResultDto> GetAllProjects();
}