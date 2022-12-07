namespace Unik.Onboarding.Application.Queries.User;

public interface IUserGetQuery
{
    UserQueryResultDto GetUser(string userId);
}