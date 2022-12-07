using Microsoft.EntityFrameworkCore;
using Unik.Onboarding.Application.Queries.User;
using Unik.Onboarding.Application.Repositories;
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

    void IUserRepository.CreateUser(UsersEntity user)
    {
        _db.Add(user);
        _db.SaveChanges();
    }

    IEnumerable<UserQueryResultDto> IUserRepository.GetAllUsers()
    {
        foreach (var entity in _db.UserEntities.AsNoTracking().ToList())
            yield return new UserQueryResultDto
            {
                Id = entity.Id,
                UserId = entity.UserId,
                RowVersion = entity.RowVersion
            };
    }

    UserQueryResultDto IUserRepository.GetUser(string userId)
    {
        var dbEntity = _db.UserEntities.AsNoTracking().FirstOrDefault(a => a.UserId == userId);
        if (dbEntity == null) throw new Exception("Denne bruger findes ikke i db");

        return new UserQueryResultDto
        {
            Id = dbEntity.Id,
            UserId = dbEntity.UserId,
            RowVersion = dbEntity.RowVersion
        };
    }

    UsersEntity IUserRepository.LoadUser(string userId)
    {
        var dbEntity = _db.UserEntities.AsNoTracking().FirstOrDefault(a => a.UserId == userId);
        if (dbEntity == null) throw new Exception("Denne bruger findes ikke i db");

        return dbEntity;
    }

    void IUserRepository.DeleteUser(UsersEntity user)
    {
        _db.Remove(user);
        _db.SaveChanges();
    }
}