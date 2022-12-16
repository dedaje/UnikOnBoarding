using Unik.Onboarding.Application.Queries.UserProjects;

namespace Unik.Onboarding.Application.Queries.User;

public interface IUserGetAllQuery
{
    IEnumerable<UserQueryResultDto> GetAllUsers();
}