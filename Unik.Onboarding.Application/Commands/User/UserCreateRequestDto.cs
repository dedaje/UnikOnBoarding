namespace Unik.Onboarding.Application.Commands.User;

public class UserCreateRequestDto
{
    public string UserId { get; set; }
    public string Name { get; set; }
    public int Phone { get; set; }
    public int RoleId { get; set; }
}