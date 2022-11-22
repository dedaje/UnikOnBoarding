namespace Unik.Onboarding.Application.Commands.User;

public class UserEditRequestDto
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public string Name { get; set; }
    public int Phone { get; set; }
    public int RoleId { get; set; }
    public byte[] RowVersion { get; set; }
}