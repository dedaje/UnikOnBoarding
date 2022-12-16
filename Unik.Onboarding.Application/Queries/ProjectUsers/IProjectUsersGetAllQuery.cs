namespace Unik.Onboarding.Application.Queries.ProjectUsers;

public interface IProjectUsersGetAllQuery
{
    IEnumerable<ProjectUsersQueryResultDto> GetAllProjectUsers(int projectId); // Gets all the users that is assigned to specific project
}