using Unik.Onboarding.Application.Queries.User;
using Unik.Onboarding.Domain.Model;

namespace Unik.Onboarding.Application.Repositories;

public interface IUserRepository
{
    void Add(UserEntity user);
    IEnumerable<UserQueryResultDto> GetAllUsers();
    IEnumerable<UserQueryResultDto> GetAllByRole(int roleId);
    UserQueryResultDto GetUser(string userId);
    UserEntity Load(int id);
    void Update(UserEntity model);
    
}