using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Onboarding.Application.Queries.User;
using Unik.Onboarding.Application.Repositories.User;

namespace Unik.Onboarding.Application.Queries.Implementation.User
{
    public class UserGetQuery : IUserGetQuery
    {
        private readonly IUserRepository _repository;

        public UserGetQuery(IUserRepository repository)
        {
            _repository = repository;
        }

        UserQueryResultDto IUserGetQuery.GetUser(int userId)
        {
            return _repository.GetUser(userId);
        }
    }
}
