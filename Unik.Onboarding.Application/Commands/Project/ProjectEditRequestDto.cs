namespace Unik.Onboarding.Application.Commands.Project;

public class ProjectEditRequestDto
{
    public int Id { get; set; }
    public string ProjectName { get; set; }
    public DateTime DateCreated { get; set; }
    public byte[] RowVersion { get; set; }
}