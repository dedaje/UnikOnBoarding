using Unik.Onboarding.Application.Commands.Onboarding;
using Unik.Onboarding.Application.Repositories;
using Unik.Onboarding.Domain.Model;

namespace Unik.Onboarding.Application.Commands.Implementation.Onboarding;

public class CreateProjectCommand : ICreateProjectCommand
{
    private readonly IProjectRepository _onboardingRepository;

    public CreateProjectCommand(IProjectRepository onboardingRepository)
    {
        _onboardingRepository = onboardingRepository;
    }

    void ICreateProjectCommand.Create(ProjectCreateRequestDto onboardingCreateRequestDto)
    {
        var onboarding = new ProjectEntity(onboardingCreateRequestDto.ProjectId, onboardingCreateRequestDto.ProjectName);
        _onboardingRepository.Add(onboarding);
    }
}