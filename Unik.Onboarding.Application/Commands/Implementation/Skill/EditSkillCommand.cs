﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Onboarding.Application.Commands.Skill;
using Unik.Onboarding.Application.Repositories.Skill;

namespace Unik.Onboarding.Application.Commands.Implementation.Skill
{
    public class EditSkillCommand : IEditSkillCommand
    {
        private readonly ISkillRepository _repository;

        public EditSkillCommand(ISkillRepository repository)
        {
            _repository = repository;
        }

        void IEditSkillCommand.Edit(SkillEditRequestDto request)
        {
            //Read
            var model = _repository.Load(request.SkillId);

            //DoIt
            model.Edit(request.SkillName, request.RowVersion);

            //Save
            _repository.Update(model);
        }
    }
}