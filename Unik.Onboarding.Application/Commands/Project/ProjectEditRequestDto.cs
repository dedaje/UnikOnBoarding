namespace Unik.Onboarding.Application.Commands.Onboarding;

public class ProjectEditRequestDto
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public string ProjectName { get; set; }
    public DateTime DateAdded { get; set; }
    public string UserId { get; set; }
    public byte[] RowVersion { get; set; }
}