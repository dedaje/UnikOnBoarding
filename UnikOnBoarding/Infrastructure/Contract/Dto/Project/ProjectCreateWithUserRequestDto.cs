using UnikOnBoarding.Infrastructure.Contract.Dto.User;

namespace UnikOnBoarding.Infrastructure.Contract.Dto.Project;

public class ProjectCreateWithUserRequestDto
{
    public ProjectCreateRequestDto ProjectCreateDto { get; set; }
    public UserQueryResultDto UserQueryDto { get; set; }
}