using Unik.Onboarding.Domain.Model;

namespace Unik.Onboarding.Application.Commands.Project;

public class ProjectCreateRequestDto
{
    public List<UsersEntity> Users { get; set; }
    public string ProjectName { get; set; }
}