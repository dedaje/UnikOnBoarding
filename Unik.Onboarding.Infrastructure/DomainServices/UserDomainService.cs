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

    //bool IUserDomainService.userExistsInProject(int projectId, string userId)
    //{
    //    return _db.ProjectEntities.AsNoTracking().ToList().Any(a => a.ProjectId == projectId && a.UserId == userId);
    //}
}