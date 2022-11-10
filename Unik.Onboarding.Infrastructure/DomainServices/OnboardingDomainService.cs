using Microsoft.EntityFrameworkCore;
using Unik.Onboarding.Domain.DomainServices;
using Unik.SqlServerContext;

namespace Unik.Onboarding.Infrastructure.DomainServices;

public class OnboardingDomainService : IOnboardingDomainService
{
    private readonly UnikDbContext _db;

    public OnboardingDomainService(UnikDbContext db)
    {
        _db = db;
    }

    bool IOnboardingDomainService.userExistsInProject(int id, List<string> userId, string specificUserId)
    {
        return _db.OnboardingEntities.AsNoTracking().ToList().Any(a => a.Id == id && userId.Contains(specificUserId));
    }
}