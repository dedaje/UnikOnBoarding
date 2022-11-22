using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Onboarding.Application.Queries.User;
using Unik.Onboarding.Application.Repositories;

namespace Unik.Onboarding.Application.Queries.Implementation.User
{
    public class UserGetAllQuery : IUserGetAllQuery
    {
        private readonly IUserRepository _repository;

        public UserGetAllQuery(IUserRepository repository)
        {
            _repository = repository;
        }

        IEnumerable<UserQueryResultDto> IUserGetAllQuery.GetAllUsers()
        {
            return _repository.GetAllUsers();
        }

        IEnumerable<UserQueryResultDto> IUserGetAllQuery.GetAllByRole(int roleId)
        {
            return _repository.GetAllByRole(roleId);
        }
    }
}
