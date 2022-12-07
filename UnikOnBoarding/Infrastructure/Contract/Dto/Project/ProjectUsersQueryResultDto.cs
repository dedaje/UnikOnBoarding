using UnikOnBoarding.Infrastructure.Contract.Dto.User;

namespace UnikOnBoarding.Infrastructure.Contract.Dto.Project;

public class ProjectUsersQueryResultDto
{
    public ProjectQueryResultDto ProjectQuery { get; set; }
    public UserQueryResultDto UserQuery { get; set; }
}