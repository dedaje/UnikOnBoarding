namespace Unik.Onboarding.Application.Queries.User;

public interface IUserGetAllQuery
{
    IEnumerable<UserQueryResultDto> GetAllUsers();
    IEnumerable<UserQueryResultDto> GetAllByRole(int roleId);
}