namespace UnikOnBoarding.Areas.Identity.Data
{
    public class ApplicationClaimTypes
    {
        public enum claims
        {
            Admin,
            Sælger,
            Teknikker,
            Converter,
            Konsulent,
            Kunde
        }

        public enum policy
        {
            AdminPolicy,
            SælgerPolicy,
            TeknikkerPolicy,
            ConverterPolicy,
            KonsulentPolicy,
            KundePolicy
        }
    }
}
