﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unik.Onboarding.Application.Commands.UserSkills
{
    public interface IEditUserSkillsCommand
    {
        void Edit(UserSkillsEditRequestDto request);
    }
}
