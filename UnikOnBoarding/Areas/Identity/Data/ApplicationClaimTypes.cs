using Enum = System.Enum;

namespace UnikOnBoarding.Areas.Identity.Data
{
    public static class ApplicationClaimTypes
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

        public static List<string> ClaimsList()
        {
            return Enum.GetNames<claims>().ToList();
        }

        public static List<string> PolicyList()
        {
            return Enum.GetNames<policy>().ToList();
        }
    }
}
