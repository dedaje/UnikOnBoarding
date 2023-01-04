using WebClient.UnikOnBoarding.Infrastructure.Contract.Dto.Project;
using WebClient.UnikOnBoarding.Infrastructure.Contract.Dto.User;

namespace WebClient.UnikOnBoarding.Infrastructure.Contract.Dto.ProjectUsers;

public class ProjectAddUserRequestDto
{
    public ProjectQueryResultDto ProjectQueryDto { get; set; }
    public UserQueryResultDto UserQueryDto { get; set; }
}