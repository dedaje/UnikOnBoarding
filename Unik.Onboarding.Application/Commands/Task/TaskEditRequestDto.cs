namespace Unik.Onboarding.Application.Commands.Task;

public class TaskEditRequestDto
{
    public int Id { get; set; }
    public string TaskName { get; set; }
    public string TaskDescription { get; set; }
    public DateTime DateCreated { get; set; }
    public int ProjectsId { get; set; }
    public string Section { get; set; }
    public int UsersId { get; set; }
    public byte[] RowVersion { get; set; }
}