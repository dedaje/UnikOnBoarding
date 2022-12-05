namespace Unik.Onboarding.Domain.DomainServices;

public interface IProjectDomainService
{
    bool projectAlreadyExists(int projectId, string userId);
}