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
                Id = entity.Id,
                UserId = entity.UserId,
                Name = entity.Name,
                Phone = (int)entity.Phone,
                RoleId = (int)entity.RoleId,
                RowVersion = entity.RowVersion
            };
    }

    IEnumerable<UserQueryResultDto> IUserRepository.GetAllUsers()
    {
        foreach (var entity in _db.UserEntities.AsNoTracking().ToList())
            yield return new UserQueryResultDto
            {
                Id = entity.Id,
                UserId = entity.UserId,
                Name = entity.Name,
                Phone = (int)entity.Phone,
                RoleId = (int)entity.RoleId,
                RowVersion = entity.RowVersion
            };
    }

    UserQueryResultDto IUserRepository.GetUser(string userId)
    {
        var dbEntity = _db.UserEntities.AsNoTracking().FirstOrDefault(a => a.UserId == userId);
        if (dbEntity == null) throw new Exception("Denne bruger findes ikke i databasen");

        return new UserQueryResultDto
        {
            Id = dbEntity.Id,
            UserId = dbEntity.UserId,
            Name = dbEntity.Name,
            Phone = (int)dbEntity.Phone,
            RoleId = (int)dbEntity.RoleId,
            RowVersion = dbEntity.RowVersion
        };
    }

    UserEntity IUserRepository.Load(int id)
    {
        var dbEntity = _db.UserEntities.AsNoTracking().FirstOrDefault(a => a.Id == id);
        if (dbEntity == null) throw new Exception("Denne bruger findes ikke i databasen");

        return dbEntity;
    }

    void IUserRepository.Update(UserEntity model)
    {
        _db.Update(model);
        _db.SaveChanges();
    }
}