﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Onboarding.Application.Queries;
using Unik.Onboarding.Domain.Model;

namespace Unik.Onboarding.Application.Repositories
{
    public interface IOnboardingRepository
    {
        void Add(OnboardingEntity onboarding);
        IEnumerable<OnboardingQueryResultDto> GetAll(string userId);
        OnboardingEntity Load(int id, string userId);
        void Update(OnboardingEntity model);
        OnboardingQueryResultDto Get(int id, string userId);
    }
}