using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unik.Onboarding.Application.Queries.Onboarding
{
    public class OnboardingQueryResultDto
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public DateTime Date { get; set; }
        public byte[] RowVersion { get; set; }

    }
}
