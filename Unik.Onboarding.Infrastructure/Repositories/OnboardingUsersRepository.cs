using Microsoft.EntityFrameworkCore;
using Unik.Onboarding.Application.Queries.OnboardingUsers;
using Unik.Onboarding.Application.Repositories.OnboardingUsers;
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
        throw new NotImplementedException();
    }

    OnboardingUsersQueryResultDto IOnboardingUsersRepository.GetOnboardingUser(int projectId, int userId)
    {
        throw new NotImplementedException();
    }

    OnboardingUsersEntity IOnboardingUsersRepository.Load(int projectId, int userId)
    {
        var dbEntity = _db.OnboardingUsersEntities.AsNoTracking().FirstOrDefault(a => a.ProjectId == projectId && a.UserId == userId);
        if (dbEntity == null) throw new Exception("Det projekt findes ikke i databasen"); //TODO: opdater

        return dbEntity;
    }

    void IOnboardingUsersRepository.Update(OnboardingUsersEntity model)
    {
        _db.Update(model);
        _db.SaveChanges();
    }
}