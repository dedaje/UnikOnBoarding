using Unik.Onboarding.Application.Queries.User;
using Unik.Onboarding.Application.Repositories.User;
using Unik.Onboarding.Domain.Model;
using Unik.SqlServerContext;

namespace Unik.Onboarding.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly UnikDbContext _db;

    public UserRepository(UnikDbContext db)
    {
        _db = db;
    }

    void IUserRepository.Add(UserEntity user)
    {
        _db.Add(user);
        _db.SaveChanges();
    }

    IEnumerable<UserQueryResultDto> IUserRepository.GetAllByRole(int roleId)
    {
        throw new NotImplementedException();
    }

    IEnumerable<UserQueryResultDto> IUserRepository.GetAllUsers()
    {
        throw new NotImplementedException();
    }

    UserQueryResultDto IUserRepository.GetUser(int userId)
    {
        throw new NotImplementedException();
    }

    UserEntity IUserRepository.Load(int userId)
    {
        throw new NotImplementedException();
    }

    void IUserRepository.Update(UserEntity model)
    {
        _db.Update(model);
        _db.SaveChanges();
    }
}