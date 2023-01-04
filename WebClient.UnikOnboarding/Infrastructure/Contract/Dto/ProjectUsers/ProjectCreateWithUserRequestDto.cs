using WebClient.UnikOnBoarding.Infrastructure.Contract.Dto.Project;
using WebClient.UnikOnBoarding.Infrastructure.Contract.Dto.User;

namespace WebClient.UnikOnBoarding.Infrastructure.Contract.Dto.ProjectUsers;

public class ProjectCreateWithUserRequestDto
{
    public ProjectCreateRequestDto ProjectCreateDto { get; set; }
    public UserQueryResultDto UserQueryDto { get; set; }
}