using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Onboarding.Application.Queries.UserSkills;
using Unik.Onboarding.Application.Repositories.UserSkills;

namespace Unik.Onboarding.Application.Queries.Implementation.UserSkills
{
    public class UserSkillsGetAllQuery : IUserSkillsGetAllQuery
    {
        private readonly IUserSkillsRepository _repository;

        public UserSkillsGetAllQuery(IUserSkillsRepository repository)
        {
            _repository = repository;
        }

        IEnumerable<UserSkillsQueryResultDto> IUserSkillsGetAllQuery.GetAllUserSkills(int userId)
        {
            return _repository.GetAllUserSkills(userId);
        }
    }
}
