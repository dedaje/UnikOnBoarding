using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unik.Onboarding.Application.Commands.Role
{
    public interface ICreateRoleRequestCommand
    {
        void Create(RoleCreateRequestDto request);
    }
}
