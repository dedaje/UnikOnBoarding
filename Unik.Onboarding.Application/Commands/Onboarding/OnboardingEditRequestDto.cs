using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unik.Onboarding.Application.Commands.Onboarding
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

