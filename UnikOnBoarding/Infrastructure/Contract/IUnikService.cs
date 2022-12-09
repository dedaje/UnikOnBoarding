﻿using UnikOnBoarding.Infrastructure.Contract.Dto;
using UnikOnBoarding.Infrastructure.Contract.Dto.Project;
using UnikOnBoarding.Infrastructure.Contract.Dto.ProjectUsers;
using UnikOnBoarding.Infrastructure.Contract.Dto.Task;
using UnikOnBoarding.Infrastructure.Contract.Dto.User;

namespace UnikOnBoarding.Infrastructure.Contract
{
    public interface IUnikService
    {
        // Project
        Task CreateProject(ProjectCreateWithUserRequestDto dto);
        Task EditProject(ProjectEditRequestDto dto);
        Task DeleteProject(int projectId);
        Task<ProjectQueryResultDto?> GetProject(int? projectId);
        Task<IEnumerable<ProjectQueryResultDto>?> GetAllProjects();

        // ProjectUsers
        Task AddUserToProject(ProjectAddUserRequestDto dto);
        Task RemoveUserFromProject(string userId, int? projectId);
        //Task RemoveUserFromProject(ProjectRemoveUserRequestDto dto);
        Task<IEnumerable<ProjectUsersQueryResultDto>?> GetAllUserProjects(int? projectId, string? userId);

        // User
        Task CreateUser(UserCreateRequestDto dto);
        Task<UserQueryResultDto> GetUser(string userId);
        Task<IEnumerable<UserQueryResultDto>?> GetAllUsers();

        // Task
        Task CreateTask(TaskCreateRequestDto dto);
        Task EditTask(TaskEditRequestDto dto);
        Task DeleteTask(int id);
        Task<TaskQueryResultDto?> GetTask(int taskId);
        Task<IEnumerable<TaskQueryResultDto>?> GetAllTasksByRole(int projectId, int roleId);
        Task<IEnumerable<TaskQueryResultDto>?> GetAllTasksByUser(int projectId, string userId);
    }
}
