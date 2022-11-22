using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Onboarding.Domain.Model;

namespace Unik.Onboarding.Application.Queries.UserSkills
{
    public class UserSkillsQueryResultDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int SkillId { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
