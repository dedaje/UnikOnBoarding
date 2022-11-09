using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Unik.Onboarding.Application.Queries;
using Unik.Onboarding.Application.Repositories;
using Unik.Onboarding.Domain.Model;
using Unik.SqlServerContext;

namespace Unik.Onboarding.Infrastructure.Repositories
{
    public class OnboardingRepository : IOnboardingRepository
    {
        private readonly UnikContext _db;

        public OnboardingRepository(UnikContext db)
        {
            _db = db;
        }

        void IOnboardingRepository.Add(OnboardingEntity onboarding)
        {
            _db.Add(onboarding);
            _db.SaveChanges();
        }

        //TODO: opdater når OnboardingEntity er ændret
        OnboardingQueryResultDto IOnboardingRepository.Get(int id, string userId)
        {
            var dbEntity = _db.OnboardingEntities.AsNoTracking().FirstOrDefault(a => a.Id == id && a.UserId == userId);
            if (dbEntity == null) throw new Exception(""); //TODO: opdater

            return new OnboardingQueryResultDto
            { Id = dbEntity.Id, Date = dbEntity.Date, };
        }

        //TODO: opdater når OnboardingEntity er ændret
        IEnumerable<OnboardingQueryResultDto> IOnboardingRepository.GetAll(string userId)
        {
            foreach (var entity in _db.OnboardingEntities.AsNoTracking().Where(a => a.UserId == userId).ToList())
                yield return new OnboardingQueryResultDto
                    { Id = entity.Id, Date = entity.Date };
        }

        //TODO: opdater når OnboardingEntity er ændret
        OnboardingEntity IOnboardingRepository.Load(int id, string userId)
        {
            var dbEntity = _db.OnboardingEntities.AsNoTracking().FirstOrDefault(a => a.Id == id && a.UserId == userId);
            if (dbEntity == null) throw new Exception(""); //TODO: opdater

            return dbEntity;
        }

        void IOnboardingRepository.Update(OnboardingEntity model)
        {
            _db.Update(model);
            _db.SaveChanges();
        }
    }
}
