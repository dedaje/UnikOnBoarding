using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unik.Onboarding.Application.Queries.Role
{
    public interface IRoleGetAllQuery
    {
        IEnumerable<RoleQueryResultDto> GetAllRoles();
    }
}
