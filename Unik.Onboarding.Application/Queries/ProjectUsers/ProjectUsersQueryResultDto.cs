using Unik.Onboarding.Application.Queries.User;
using Unik.Onboarding.Domain.Model;

namespace Unik.Onboarding.Application.Queries.ProjectUsers;

public class ProjectUsersQueryResultDto
{
    public int ProjectId { get; set; }
    public string ProjectName { get; set; }
    public DateTime DateCreated { get; set; }
    public byte[] RowVersion { get; set; }

    public string UserId { get; set; }
}