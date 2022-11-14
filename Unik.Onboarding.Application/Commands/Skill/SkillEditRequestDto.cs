using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unik.Onboarding.Application.Commands.Skill
{
    public class SkillEditRequestDto
    {
        public int SkillId { get; set; } 
        public string SkillName { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
