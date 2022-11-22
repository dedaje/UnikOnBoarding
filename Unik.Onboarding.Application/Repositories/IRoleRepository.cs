using Unik.Onboarding.Application.Queries.Role;
using Unik.Onboarding.Domain.Model;

namespace Unik.Onboarding.Application.Repositories;

public interface IRoleRepository
{
    void Add(RoleEntity role);
    IEnumerable<RoleQueryResultDto> GetAllRoles();
    RoleQueryResultDto GetRole(int roleId);
    RoleEntity Load(int roleId);
    void Update(RoleEntity model);
}