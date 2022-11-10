using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Onboarding.Domain.DomainServices;

namespace Unik.Onboarding.Domain.Model
{
    public class OnboardingEntity
    {
        private readonly IOnboardingDomainService _domainService;

        // For Entity Framework only!!!
        internal OnboardingEntity()
        {

        }

        public OnboardingEntity(IOnboardingDomainService domainService, List<string> userId, string specificUserId, string projektNavn)
        {
            _domainService = domainService;
            UserId = userId;
            SpecificUserId = specificUserId;
            ProjektNavn = projektNavn;

            if (_domainService.userExistsInProject(Id, UserId, SpecificUserId)) throw new ArgumentException("Den bruger eksisterer allerede i det projekt");

            AddUser();
        }

        public int Id { get; }
        public List<string> UserId { get; private set; }
        public string ProjektNavn { get; private set; }
        public DateTime Date { get; private set; }
        [NotMapped] public string? SpecificUserId { get; private set; }

        [Timestamp]
        public byte[] RowVersion { get; private set; }

        public void AddUser() //List<string> userId, string specificUserId, byte[] rowVersion
        {
            //UserId = userId;
            //SpecificUserId = specificUserId;
            //RowVersion = rowVersion;

            UserId.Add(SpecificUserId);
        }

        public void Edit(List<string> userId, string projektNavn, byte[] rowVersion)
        {
            UserId = userId;
            RowVersion = rowVersion;
            ProjektNavn = projektNavn;
        }

        public void RemoveUser(List<string> userId, string specificUserId, byte[] rowVersion)
        {
            UserId = userId;
            SpecificUserId = specificUserId;
            RowVersion = rowVersion;

            if (!_domainService.userExistsInProject(Id, UserId, SpecificUserId)) throw new ArgumentException("Den bruger eksisterer ikke i det projekt");

            UserId.Remove(SpecificUserId);
        }
    }
}
