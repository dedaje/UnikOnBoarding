using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Onboarding.Application.Commands.Onboarding;
using Unik.Onboarding.Application.Repositories.Onboarding;

namespace Unik.Onboarding.Application.Commands.Implementation
{
    public class EditOnboardingCommand : IEditOnboardingCommand
    {
        private readonly IOnboardingRepository _repository;

        public EditOnboardingCommand(IOnboardingRepository repository)
        {
            _repository = repository;
        }

        void IEditOnboardingCommand.AddUser(OnboardingEditRequestDto requestDto)
        {
            //Read
            var model = _repository.Load(requestDto.Id);
            //DoIt

            model.AddUser(); //requestDto.UserId, requestDto.SpecificUserId, requestDto.RowVersion

            //Save
            _repository.Update(model);
        }

        void IEditOnboardingCommand.Edit(OnboardingEditRequestDto requestDto)
        {
            //Read
            var model = _repository.Load(requestDto.Id);
            //DoIt

            model.Edit(requestDto.UserId, requestDto.ProjektNavn, requestDto.RowVersion);

            //Save
            _repository.Update(model);
        }

        void IEditOnboardingCommand.RemoveUser(OnboardingEditRequestDto requestDto)
        {
            //Read
            var model = _repository.Load(requestDto.Id);
            //DoIt

            model.RemoveUser(requestDto.UserId, requestDto.SpecificUserId, requestDto.RowVersion);

            //Save
            _repository.Update(model);
        }
    }
}
