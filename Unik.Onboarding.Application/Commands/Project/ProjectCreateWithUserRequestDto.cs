using Unik.Onboarding.Application.Queries.User;

namespace Unik.Onboarding.Application.Commands.Project;

public class ProjectCreateWithUserRequestDto
{
    public ProjectCreateRequestDto ProjectCreateDto { get; set; }
    public UserQueryResultDto UserQueryDto { get; set; }
}