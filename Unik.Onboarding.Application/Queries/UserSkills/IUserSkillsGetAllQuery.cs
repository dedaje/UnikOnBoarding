﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unik.Onboarding.Application.Queries.UserSkills
{
    public interface IUserSkillsGetAllQuery
    {
        IEnumerable<UserSkillsQueryResultDto> GetAllUserSkills(int userId);
    }
}
