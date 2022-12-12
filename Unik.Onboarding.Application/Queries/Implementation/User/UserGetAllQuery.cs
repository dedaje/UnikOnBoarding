﻿using Unik.Onboarding.Application.Queries.User;
using Unik.Onboarding.Application.Queries.UserProjects;
using Unik.Onboarding.Application.Repositories;

namespace Unik.Onboarding.Application.Queries.Implementation.User;

public class UserGetAllQuery : IUserGetAllQuery
{
    private readonly IUserRepository _repository;

    public UserGetAllQuery(IUserRepository repository)
    {
        _repository = repository;
    }

    IEnumerable<UserProjectsQueryResultDto> IUserGetAllQuery.GetAllUserProjects(string userId)
    {
        return _repository.GetAllUserProjects(userId);
    }

    IEnumerable<UserQueryResultDto> IUserGetAllQuery.GetAllUsers()
    {
        return _repository.GetAllUsers();
    }
}