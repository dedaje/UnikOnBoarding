using Microsoft.EntityFrameworkCore;
using Unik.Onboarding.Application.Queries.OnboardingUsers;
using Unik.Onboarding.Application.Repositories;
using Unik.Onboarding.Domain.Model;
using Unik.SqlServerContext;

namespace Unik.Onboarding.Infrastructure.Repositories;

public class OnboardingUsersRepository : IOnboardingUsersRepository
{
    private readonly UnikDbContext _db;

    public OnboardingUsersRepository(UnikDbContext db)
    {
        _db = db;
    }

    void IOnboardingUsersRepository.Add(OnboardingUsersEntity onboardingUsers)
    {
        _db.Add(onboardingUsers);
        _db.SaveChanges();
    }

    IEnumerable<OnboardingUsersQueryResultDto> IOnboardingUsersRepository.GetAllOnboardingUsers(int projectId)
    {
        foreach (var entity in _db.OnboardingUsersEntities.AsNoTracking().Where(a => a.ProjectId == projectId).ToList())
            yield return new OnboardingUsersQueryResultDto
            {
                Id = entity.Id,
                ProjectId = entity.ProjectId,
                RowVersion = entity.RowVersion,
                UserId = entity.UserId
            };
    }

    OnboardingUsersQueryResultDto IOnboardingUsersRepository.GetOnboardingUser(int projectId, string userId)
    {
        var dbEntity = _db.OnboardingUsersEntities.AsNoTracking()
            .FirstOrDefault(a => a.ProjectId == projectId && a.UserId == userId);
        if (dbEntity == null) throw new Exception("Denne bruger findes ikke i dette projekt");

        return new OnboardingUsersQueryResultDto
        {
            Id = dbEntity.Id,
            ProjectId = dbEntity.ProjectId,
            RowVersion = dbEntity.RowVersion,
            UserId = dbEntity.UserId
        };
    }

    OnboardingUsersEntity IOnboardingUsersRepository.Load(int projectId, string userId)
    {
        var dbEntity = _db.OnboardingUsersEntities.AsNoTracking()
            .FirstOrDefault(a => a.ProjectId == projectId && a.UserId == userId);
        if (dbEntity == null) throw new Exception("Det projekt findes ikke i databasen"); //TODO: opdater

        return dbEntity;
    }

    void IOnboardingUsersRepository.Update(OnboardingUsersEntity model)
    {
        _db.Update(model);
        _db.SaveChanges();
    }
}