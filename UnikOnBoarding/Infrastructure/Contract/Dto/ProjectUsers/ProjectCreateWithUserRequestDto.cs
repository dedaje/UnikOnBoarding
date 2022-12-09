using UnikOnBoarding.Infrastructure.Contract.Dto.Project;
using UnikOnBoarding.Infrastructure.Contract.Dto.User;

namespace UnikOnBoarding.Infrastructure.Contract.Dto.ProjectUsers;

public class ProjectCreateWithUserRequestDto
{
    public ProjectCreateRequestDto ProjectCreateDto { get; set; }
    public UserQueryResultDto UserQueryDto { get; set; }
}