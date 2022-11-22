namespace Unik.Onboarding.Application.Queries.User;

public class UserQueryResultDto
{
    public string UserId { get; set; }
    public string Name { get; set; }
    public int Phone { get; set; }
    public int RoleId { get; set; }
    public byte[] RowVersion { get; set; }
}