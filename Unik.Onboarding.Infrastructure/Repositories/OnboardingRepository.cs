using Microsoft.EntityFrameworkCore;
using Unik.Onboarding.Application.Queries.Onboarding;
using Unik.Onboarding.Application.Repositories;
using Unik.Onboarding.Domain.Model;
using Unik.SqlServerContext;

namespace Unik.Onboarding.Infrastructure.Repositories;

public class OnboardingRepository : IOnboardingRepository
{
    private readonly UnikDbContext _db;

    public OnboardingRepository(UnikDbContext db)
    {
        _db = db;
    }

    void IOnboardingRepository.Add(OnboardingEntity onboarding)
    {
        _db.Add(onboarding);
        _db.SaveChanges();
    }

    IEnumerable<OnboardingQueryResultDto> IOnboardingRepository.GetAllProjects()
    {
        foreach (var entity in _db.OnboardingEntities.AsNoTracking().ToList())
            yield return new OnboardingQueryResultDto
            {
                ProjectId = entity.ProjectId,
                Date = entity.DateCreated,
                ProjectName = entity.ProjectName
            };
    }

    OnboardingQueryResultDto IOnboardingRepository.GetProject(int projectId)
    {
        var dbEntity = _db.OnboardingEntities.AsNoTracking()
            .FirstOrDefault(a => a.ProjectId == projectId);
        if (dbEntity == null) throw new Exception("Dette projekt findes ikke"); 

        return new OnboardingQueryResultDto
        {
            ProjectId = dbEntity.ProjectId,
            Date = dbEntity.DateCreated,
            ProjectName = dbEntity.ProjectName
        };
    }

    OnboardingEntity IOnboardingRepository.Load(int projectId) // Load metoden er til at hente data for Commands
    {
        var dbEntity = _db.OnboardingEntities.AsNoTracking().FirstOrDefault(a => a.ProjectId == projectId);
        if (dbEntity == null) throw new Exception("Det projekt findes ikke i databasen");

        return dbEntity;
    }

    void IOnboardingRepository.Update(OnboardingEntity model)
    {
        _db.Update(model);
        _db.SaveChanges();
    }
}