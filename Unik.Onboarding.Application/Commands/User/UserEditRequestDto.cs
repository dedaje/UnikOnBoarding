using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Onboarding.Domain.Model;

namespace Unik.Onboarding.Application.Commands.User
{
    public class UserEditRequestDto
    {
        public int UserId { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public int RoleId { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
