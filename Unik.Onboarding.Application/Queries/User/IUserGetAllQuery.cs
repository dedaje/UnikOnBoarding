using Unik.Onboarding.Application.Queries.UserProjects;

namespace Unik.Onboarding.Application.Queries.User;

public interface IUserGetAllQuery
{
    IEnumerable<UserProjectsQueryResultDto> GetAllUserProjects(string userId); //Gets all the projects that the logged in user is assigned to
    IEnumerable<UserQueryResultDto> GetAllUsers();
    //IEnumerable<UserQueryResultDto> GetAllUserProjects(string userId);
}