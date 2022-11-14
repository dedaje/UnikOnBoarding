using System.ComponentModel.DataAnnotations;

namespace Unik.Onboarding.Domain.Model;

public class OnboardingEntity
{
    //private readonly IOnboardingDomainService _domainService;

    // For Entity Framework only!!!
    internal OnboardingEntity()
    {
    }

    public OnboardingEntity( /*IOnboardingDomainService domainService*/ string projectName)
    {
        //_domainService = domainService;
        ProjectName = projectName;
        DateCreated = DateTime.Now;

        //if (_domainService.userExistsInProject(ProjectId, UserId, SpecificUserId)) throw new ArgumentException("Den bruger eksisterer allerede i det projekt");
    }

    public int ProjectId { get; } // PK
    public string ProjectName { get; private set; }

    public DateTime DateCreated { get; }

    //public DateTime? DateModified { get; private set; }
    [Timestamp] public byte[] RowVersion { get; private set; }

    public void Edit(string projectName, byte[] rowVersion)
    {
        ProjectName = projectName;
        RowVersion = rowVersion;
        //DateModified = DateTime.Now;

        throw new NotImplementedException();
    }
}