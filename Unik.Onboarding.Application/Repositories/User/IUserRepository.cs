using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Onboarding.Application.Queries.User;
using Unik.Onboarding.Domain.Model;

namespace Unik.Onboarding.Application.Repositories.User
{
    public interface IUserRepository
    {
        void Add(UserEntity user);
        IEnumerable<UserQueryResultDto> GetAllUsers();
        IEnumerable<UserQueryResultDto> GetAllByRole(int roleId);
        UserEntity Load(int userId);
        void Update(UserEntity model);
        UserQueryResultDto GetUser(int userId);
    }
}
