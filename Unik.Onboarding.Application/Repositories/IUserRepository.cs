using Unik.Onboarding.Application.Queries.User;
using Unik.Onboarding.Domain.Model;

namespace Unik.Onboarding.Application.Repositories;

public interface IUserRepository
{
    void CreateUser(UsersEntity user);
    IEnumerable<UserQueryResultDto> GetAllUsers();
    UserQueryResultDto GetUser(string userId);
    UsersEntity LoadUser(string userId);
    //void UpdateUser(ProjectEntity model);
    void DeleteUser(UsersEntity user);
}