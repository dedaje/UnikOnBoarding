namespace UnikOnBoarding.Infrastructure.Contract.Dto;

public class RemoveUserRequestDto
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public string ProjectName { get; set; }
    public string UserId { get; set; }
}