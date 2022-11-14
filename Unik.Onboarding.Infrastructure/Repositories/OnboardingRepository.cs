using Microsoft.EntityFrameworkCore;
using Unik.Onboarding.Application.Queries.Onboarding;
using Unik.Onboarding.Application.Repositories.Onboarding;
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

    //TODO: opdater når OnboardingEntity er ændret
    OnboardingEntity IOnboardingRepository.Load(int projectId) // Load metoden er til at hente data for Commands
    {
        var dbEntity = _db.OnboardingEntities.AsNoTracking().FirstOrDefault(a => a.ProjectId == projectId);
        if (dbEntity == null) throw new Exception("Det projekt findes ikke i databasen"); //TODO: opdater

        return dbEntity;
    }

    void IOnboardingRepository.Update(OnboardingEntity model)
    {
        _db.Update(model);
        _db.SaveChanges();
    }

    //TODO: opdater når OnboardingEntity er ændret
    OnboardingQueryResultDto IOnboardingRepository.GetProject(int projectId)
    {
        var dbEntity = _db.OnboardingEntities.AsNoTracking()
            .FirstOrDefault(a => a.ProjectId == projectId);
        if (dbEntity == null) throw new Exception("Dette projekt findes ikke"); //TODO: opdater

        return new OnboardingQueryResultDto
            { ProjectId = dbEntity.ProjectId, Date = dbEntity.DateCreated, ProjectName = dbEntity.ProjectName};
    }

    //TODO: opdater når OnboardingEntity er ændret
    IEnumerable<OnboardingQueryResultDto> IOnboardingRepository.GetAllProjects()
    {
        foreach (var entity in _db.OnboardingEntities.AsNoTracking().ToList())
            yield return new OnboardingQueryResultDto
                { ProjectId = entity.ProjectId, Date = entity.DateCreated, ProjectName = entity.ProjectName };
    }
}