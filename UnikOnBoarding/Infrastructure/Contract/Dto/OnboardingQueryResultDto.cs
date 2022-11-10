namespace UnikOnBoarding.Infrastructure.Contract.Dto
{
    public class OnboardingQueryResultDto
    {
        public int Id { get; set; }
        public List<string> UserId { get; set; }
        public DateTime Date { get; set; }
        public string ProjektNavn { get; set; }
    }
}
