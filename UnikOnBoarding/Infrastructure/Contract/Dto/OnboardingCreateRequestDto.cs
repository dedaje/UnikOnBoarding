namespace UnikOnBoarding.Infrastructure.Contract.Dto
{
    public class OnboardingCreateRequestDto
    {
        public List<string> UserId { get; set; }
        public string? SpecificUserId { get; set; }
        public string ProjektNavn { get; set; }
    }
}
