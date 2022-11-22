namespace Unik.Onboarding.Application.Queries.OnboardingUsers;

public class OnboardingUsersQueryResultDto
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public string UserId { get; set; }
    public byte[] RowVersion { get; set; }
}