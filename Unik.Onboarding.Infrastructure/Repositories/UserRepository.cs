using Microsoft.EntityFrameworkCore;
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

    void IUserRepository.AddUser(ProjectEntity user)
    {
        _db.Add(user);
        _db.SaveChanges();
    }

    ProjectEntity IUserRepository.Load(int projectId, string userId)
    {
        var dbEntity = _db.ProjectEntities.AsNoTracking().FirstOrDefault(a => a.ProjectId == projectId && a.UserId == userId);
        if (dbEntity == null) throw new Exception("Denne bruger var ikke en del af projektet");

        return dbEntity;
    }

    void IUserRepository.RemoveUser(ProjectEntity user)
    {
        _db.Remove(user);
        _db.SaveChanges();
    }
}