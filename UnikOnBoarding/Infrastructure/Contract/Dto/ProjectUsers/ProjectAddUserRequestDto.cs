using UnikOnBoarding.Infrastructure.Contract.Dto.Project;
using UnikOnBoarding.Infrastructure.Contract.Dto.User;

namespace UnikOnBoarding.Infrastructure.Contract.Dto.ProjectUsers;

public class ProjectAddUserRequestDto
{
    public ProjectQueryResultDto ProjectQueryDto { get; set; }
    public UserQueryResultDto UserQueryDto { get; set; }
}