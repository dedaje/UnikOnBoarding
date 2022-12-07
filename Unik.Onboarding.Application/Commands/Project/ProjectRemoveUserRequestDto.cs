﻿using Unik.Onboarding.Application.Queries.Project;
using Unik.Onboarding.Application.Queries.User;

namespace Unik.Onboarding.Application.Commands.Project;

public class ProjectRemoveUserRequestDto
{
    public ProjectQueryResultDto ProjectQueryDto { get; set; }
    public UserQueryResultDto UserQueryDto { get; set; }
}