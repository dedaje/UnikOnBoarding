using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Onboarding.Application.Queries.Role;
using Unik.Onboarding.Application.Repositories.Role;

namespace Unik.Onboarding.Application.Queries.Implementation.Role
{
    public class RoleGetQuery : IRoleGetQuery
    {
        private readonly IRoleRepository _repository;

        public RoleGetQuery(IRoleRepository repository)
        {
            _repository = repository;
        }

        RoleQueryResultDto IRoleGetQuery.GetRole(int roleId)
        {
            return _repository.GetRole(roleId);
        }
    }
}
