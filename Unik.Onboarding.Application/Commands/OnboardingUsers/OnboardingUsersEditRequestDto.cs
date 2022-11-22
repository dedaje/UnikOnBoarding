using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Onboarding.Domain.Model;

namespace Unik.Onboarding.Application.Commands.OnboardingUsers
{
    public class OnboardingUsersEditRequestDto
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string UserId { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
