using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Onboarding.Application.Queries.Role;
using Unik.Onboarding.Application.Repositories;

namespace Unik.Onboarding.Application.Queries.Implementation.Role
{
    public class RoleGetAllQuery : IRoleGetAllQuery
    {
        private readonly IRoleRepository _repository;

        public RoleGetAllQuery(IRoleRepository repository)
        {
            _repository = repository;
        }

        IEnumerable<RoleQueryResultDto> IRoleGetAllQuery.GetAllRoles()
        {
            return _repository.GetAllRoles();
        }
    }
}
