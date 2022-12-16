namespace Unik.Onboarding.Application.Queries.UserProjects;

public interface IUserProjectsGetAllQuery
{
    IEnumerable<UserProjectsQueryResultDto> GetAllUserProjects(int? usersId); //Gets all the projects that the logged in user is assigned to
}