using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unik.Onboarding.Application.Queries.User
{
    public interface IUserGetAllQuery
    {
        IEnumerable<UserQueryResultDto> GetAllUsers();
        IEnumerable<UserQueryResultDto> GetAllByRole(int roleId);
    }
}
