﻿using Unik.Onboarding.Application.Queries.Role;
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
        throw new NotImplementedException();
    }

    RoleQueryResultDto IRoleRepository.GetRole(int roleId)
    {
        throw new NotImplementedException();
    }

    RoleEntity IRoleRepository.Load(int roleId)
    {
        throw new NotImplementedException();
    }

    void IRoleRepository.Update(RoleEntity model)
    {
        _db.Update(model);
        _db.SaveChanges();
    }
}