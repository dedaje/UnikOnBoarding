using Unik.Onboarding.Application.Commands.User;

namespace Unik.Onboarding.Application.Commands.Project;

public class ProjectCreateWithUserRequestDto
{
    public ProjectCreateRequestDto ProjectCreateRequestDto { get; set; }
    public AddUserRequestDto AddUserRequestDto { get; set; }
}