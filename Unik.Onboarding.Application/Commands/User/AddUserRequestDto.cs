using Unik.Onboarding.Domain.Model;

namespace Unik.Onboarding.Application.Commands.User;

public class AddUserRequestDto
{
    public List<ProjectEntity> Projects { get; set; }
    public string UserId { get; set; }
}