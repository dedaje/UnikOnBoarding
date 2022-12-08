using Unik.Onboarding.Application.Queries.User;
using Unik.Onboarding.Domain.Model;

namespace Unik.Onboarding.Application.Queries.Project;

public class ProjectUsersQueryResultDto
{
    public ProjectQueryResultDto ProjectQuery { get; set; }
    //public UserQueryResultDto UserQuery { get; set; }

    //public int ProjectId { get; set; }
    public List<UsersEntity> Users { get; set; }
    //public string ProjectName { get; set; }
    //public DateTime DateCreated { get; set; }
    //public byte[] RowVersion { get; set; }
}