using Microsoft.EntityFrameworkCore;
using Unik.Onboarding.Domain.DomainServices;
using Unik.SqlServerContext;

namespace Unik.Onboarding.Infrastructure.DomainServices;

public class UserDomainService : IUserDomainService
{
    private readonly UnikDbContext _db;

    public UserDomainService(UnikDbContext db)
    {
        _db = db;
    }

    //bool IUserDomainService.UserExistsInProject(int projectId, int usersId)
    //{
    //    //return _db.ProjectEntities.AsNoTracking().ToList().Any(a => a.ProjectId == projectId && a.UsersId == usersId);
    //    //var projectUsers = _db.UserEntities.AsNoTracking().Include(u => u.Projects.Where(p => p.Id == projectId));
    //}
}