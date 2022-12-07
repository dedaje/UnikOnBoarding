using Unik.Onboarding.Application.Queries.User;

namespace Unik.Onboarding.Application.Queries.Project;

public class ProjectUsersQueryResultDto
{
    public ProjectQueryResultDto ProjectQuery { get; set; }
    public UserQueryResultDto UserQuery { get; set; }
}