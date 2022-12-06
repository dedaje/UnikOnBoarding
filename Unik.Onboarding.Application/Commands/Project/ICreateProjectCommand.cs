using Unik.Onboarding.Application.Commands.User;

namespace Unik.Onboarding.Application.Commands.Project;

public interface ICreateProjectCommand
{
    void Create(ProjectCreateWithUserRequestDto request);
}