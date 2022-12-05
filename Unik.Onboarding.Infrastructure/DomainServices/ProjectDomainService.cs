using Microsoft.EntityFrameworkCore;
using Unik.Onboarding.Domain.DomainServices;
using Unik.SqlServerContext;

namespace Unik.Onboarding.Infrastructure.DomainServices;

public class ProjectDomainService : IProjectDomainService
{
    private readonly UnikDbContext _db;

    public ProjectDomainService(UnikDbContext db)
    {
        _db = db;
    }

    bool IProjectDomainService.projectAlreadyExists(int projectId, string userId)
    {
        return _db.ProjectEntities.AsNoTracking().ToList().Any(a => a.ProjectId == projectId && a.UserId == userId);
    }
}