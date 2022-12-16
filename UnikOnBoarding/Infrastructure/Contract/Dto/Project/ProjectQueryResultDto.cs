namespace UnikOnBoarding.Infrastructure.Contract.Dto.Project;

public class ProjectQueryResultDto
{
    public int Id { get; set; }
    public string ProjectName { get; set; }
    public DateTime DateCreated { get; set; }
    public byte[] RowVersion { get; set; }
}