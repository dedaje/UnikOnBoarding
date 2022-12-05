namespace Unik.Onboarding.Application.Commands.Project;

public class ProjectDeleteRequestDto
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public string ProjectName { get; set; }
}