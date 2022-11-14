using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unik.Onboarding.Application.Commands.Role
{
    public class RoleEditRequestDto
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
