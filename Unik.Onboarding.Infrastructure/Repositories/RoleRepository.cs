using Microsoft.EntityFrameworkCore;
using Unik.Onboarding.Application.Queries.Role;
using Unik.Onboarding.Application.Repositories.Role;
using Unik.Onboarding.Domain.Model;
using Unik.SqlServerContext;

namespace Unik.Onboarding.Infrastructure.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly UnikDbContext _db;

    public RoleRepository(UnikDbContext db)
    {
        _db = db;
    }

    void IRoleRepository.Add(RoleEntity role)
    {
        _db.Add(role);
        _db.SaveChanges();
    }

    IEnumerable<RoleQueryResultDto> IRoleRepository.GetAllRoles()
    {
        foreach (var entity in _db.RoleEntities.AsNoTracking().ToList())
            yield return new RoleQueryResultDto
            {
                RoleId = entity.RoleId,
                RoleName = entity.RoleName,
                RowVersion = entity.RowVersion
            };
    }

    RoleQueryResultDto IRoleRepository.GetRole(int roleId)
    {
        var dbEntity = _db.RoleEntities.AsNoTracking().FirstOrDefault(a => a.RoleId == roleId);
        if (dbEntity == null) throw new Exception("Denne rolle findes ikke i databasen");

        return new RoleQueryResultDto
        {
            RoleId = dbEntity.RoleId,
            RoleName = dbEntity.RoleName,
            RowVersion = dbEntity.RowVersion
        };
    }

    RoleEntity IRoleRepository.Load(int roleId)
    {
        var dbEntity = _db.RoleEntities.AsNoTracking().FirstOrDefault(a => a.RoleId == roleId);
        if (dbEntity == null) throw new Exception("Denne rolle findes ikke i databasen");

        return dbEntity;
    }

    void IRoleRepository.Update(RoleEntity model)
    {
        _db.Update(model);
        _db.SaveChanges();
    }
}