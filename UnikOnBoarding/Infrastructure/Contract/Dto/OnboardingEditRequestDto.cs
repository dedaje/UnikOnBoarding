namespace UnikOnBoarding.Infrastructure.Contract.Dto
{
    public class OnboardingEditRequestDto
    {
        public int Id { get; set; }
        public List<string> UserId { get; set; }
        public string SpecificUserId { get; set; }
        public string ProjektNavn { get; set; }
        public DateTime Date { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
