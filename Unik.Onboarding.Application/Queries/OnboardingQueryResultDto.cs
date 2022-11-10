﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unik.Onboarding.Application.Queries
{
    public class OnboardingQueryResultDto
    {
        public int Id { get; set; }
        public List<string> UserId { get; set; }
        public DateTime Date { get; set; }
        public string ProjektNavn { get; set; }
    }
}
