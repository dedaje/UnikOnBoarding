﻿using Unik.Onboarding.Domain.Model;

namespace Unik.Onboarding.Application.Repositories;

public interface IUserRepository
{
    void AddUser(ProjectEntity user);
    void RemoveUser(ProjectEntity user);
    //IEnumerable<ProjectQueryResultDto> GetAllUserProjects(string userId);
    //IEnumerable<ProjectQueryResultDto> GetAllEditProjects(int? projectId);
    //ProjectQueryResultDto GetProject(string userId, int projectId);
    ProjectEntity Load(int projectId, string userId);
    //void Update(ProjectEntity model);
}