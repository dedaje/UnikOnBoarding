using UnikOnBoarding.Infrastructure.Contract.Dto.User;

namespace UnikOnBoarding.Infrastructure.Contract.Dto.ProjectUsers;

public class ProjectUsersQueryResultDto
{
    public int Id { get; set; }
    public string ProjectName { get; set; }
    public DateTime DateCreated { get; set; }
    public byte[] RowVersion { get; set; }

    public string UserId { get; set; }
}