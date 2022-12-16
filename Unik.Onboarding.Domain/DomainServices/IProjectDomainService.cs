namespace Unik.Onboarding.Domain.DomainServices;

public interface IProjectDomainService
{
    bool ProjectAlreadyExists(string projectName);
}