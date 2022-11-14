using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Onboarding.Application.Queries.Role;
using Unik.Onboarding.Domain.Model;

namespace Unik.Onboarding.Application.Repositories.Role
{
    public interface IRoleRepository
    {
        void Add(RoleEntity role);
        IEnumerable<RoleQueryResultDto> GetAllRoles();
        RoleEntity Load(int roleId);
        void Update(RoleEntity model);
        RoleQueryResultDto GetRole(int roleId);
    }
}
