namespace Unik.Onboarding.Application.Queries.Project;

public class ProjectQueryResultDto
{
    public int Id { get; set; }
    public string ProjectName { get; set; }
    public DateTime DateCreated { get; set; }
    public byte[] RowVersion { get; set; }
}