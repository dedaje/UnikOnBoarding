using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unik.Onboarding.Application.Queries.Role
{
    public class RoleQueryResultDto
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
