using Microsoft.EntityFrameworkCore;
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
        foreach (var entity in _db.UserEntities.AsNoTracking().Where(a => a.RoleId == roleId).ToList())
            yield return new UserQueryResultDto
            {
                UserId = entity.UserId,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Email = entity.Email,
                Phone = entity.Phone,
                RoleId = entity.RoleId,
                RowVersion = entity.RowVersion
            };
    }

    IEnumerable<UserQueryResultDto> IUserRepository.GetAllUsers()
    {
        foreach (var entity in _db.UserEntities.AsNoTracking().ToList())
            yield return new UserQueryResultDto
            {
                UserId = entity.UserId,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Email = entity.Email,
                Phone = entity.Phone,
                RoleId = entity.RoleId,
                RowVersion = entity.RowVersion
            };
    }

    UserQueryResultDto IUserRepository.GetUser(int userId)
    {
        var dbEntity = _db.UserEntities.AsNoTracking().FirstOrDefault(a => a.UserId == userId);
        if (dbEntity == null) throw new Exception("Denne bruger findes ikke i databasen");

        return new UserQueryResultDto
        {
            UserId = dbEntity.UserId,
            FirstName = dbEntity.FirstName,
            LastName = dbEntity.LastName,
            Email = dbEntity.Email,
            Phone = dbEntity.Phone,
            RoleId = dbEntity.RoleId,
            RowVersion = dbEntity.RowVersion
        };
    }

    UserEntity IUserRepository.Load(int userId)
    {
        var dbEntity = _db.UserEntities.AsNoTracking().FirstOrDefault(a => a.UserId == userId);
        if (dbEntity == null) throw new Exception("Denne bruger findes ikke i databasen");

        return dbEntity;
    }

    void IUserRepository.Update(UserEntity model)
    {
        _db.Update(model);
        _db.SaveChanges();
    }
}