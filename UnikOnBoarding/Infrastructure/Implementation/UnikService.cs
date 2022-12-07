using Microsoft.CodeAnalysis;
using System;
using System.Threading.Tasks;
using UnikOnBoarding.Infrastructure.Contract;
using UnikOnBoarding.Infrastructure.Contract.Dto;
using UnikOnBoarding.Infrastructure.Contract.Dto.Project;
using UnikOnBoarding.Infrastructure.Contract.Dto.Task;
using UnikOnBoarding.Infrastructure.Contract.Dto.User;

namespace UnikOnBoarding.Infrastructure.Implementation
{
    public class UnikService : IUnikService
    {
        private readonly HttpClient _httpClient;

        public UnikService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Project
        async Task IUnikService.CreateProject(ProjectCreateWithUserRequestDto dto)
        {
           var response = await _httpClient.PostAsJsonAsync($"api/Project/CreateProject", dto);

           if (response.IsSuccessStatusCode) return;

           var message = await response.Content.ReadAsStringAsync();
           throw new Exception(message);
        }

        async Task IUnikService.EditProject(ProjectEditRequestDto dto)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Project/EditProject", dto);

            if (response.IsSuccessStatusCode) return;

            var message = await response.Content.ReadAsStringAsync();
            throw new Exception(message);
        }

        async Task IUnikService.RemoveUserFromProject(string userId, int? projectId)
        {
            var response = await _httpClient.DeleteAsync($"api/Project/RemoveUserFromProject/{userId}/{projectId}/");

            if (response.IsSuccessStatusCode) return;

            var message = await response.Content.ReadAsStringAsync();
            throw new Exception(message);
        }

        async Task IUnikService.DeleteProject(int projectId)
        {
            var response = await _httpClient.DeleteAsync($"api/Project/DeleteProject/{projectId}/");

            if (response.IsSuccessStatusCode) return;

            var message = await response.Content.ReadAsStringAsync();
            throw new Exception(message);
        }

        async Task<ProjectQueryResultDto?> IUnikService.GetProject(int? projectId)
        {
            return await _httpClient.GetFromJsonAsync<ProjectQueryResultDto>($"api/Project/{projectId}/");
        }

        async Task<IEnumerable<ProjectUsersQueryResultDto>?> IUnikService.GetAllUserProjects(int? projectId, int? userId)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<ProjectUsersQueryResultDto>>($"api/Project/{projectId}/{userId}/");
        }

        async Task<IEnumerable<ProjectQueryResultDto>?> IUnikService.GetAllProjects()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<ProjectQueryResultDto>>($"api/Project/p/AllProjects/");
        }

        // User
        async Task IUnikService.CreateUser(AddUserRequestDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/User/AddUser", dto);

            if (response.IsSuccessStatusCode) return;

            var message = await response.Content.ReadAsStringAsync();
            throw new Exception(message);
        }

        

        async Task<UserQueryResultDto> IUnikService.GetUser(string userId)
        {
            return await _httpClient.GetFromJsonAsync<UserQueryResultDto>($"api/User/{userId}/");
        }

        async Task<IEnumerable<UserQueryResultDto>?> IUnikService.GetAllUsers()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<UserQueryResultDto>>($"api/User/AllUsers/");
        }

        // Task
        async Task IUnikService.CreateTask(TaskCreateRequestDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/Task/Create", dto);

            if (response.IsSuccessStatusCode) return;

            var message = await response.Content.ReadAsStringAsync();
            throw new Exception(message);
        }

        async Task IUnikService.EditTask(TaskEditRequestDto dto)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Task/Edit", dto);

            if (response.IsSuccessStatusCode) return;

            var messege = await response.Content.ReadAsStringAsync();
            throw new Exception(messege);
        }

        async Task IUnikService.DeleteTask(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Task/DeleteTask/{id}/");

            if (response.IsSuccessStatusCode) return;

            var message = await response.Content.ReadAsStringAsync();
            throw new Exception(message);
        }

        async Task<TaskQueryResultDto?> IUnikService.GetTask(int taskId)
        {
            return await _httpClient.GetFromJsonAsync<TaskQueryResultDto>($"api/Task/{taskId}/");
        }

        async Task<IEnumerable<TaskQueryResultDto>?> IUnikService.GetAllTasksByRole(int projectId, int roleId)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<TaskQueryResultDto>>($"api/Task/r/{projectId}/{roleId}/");
        }

        async Task<IEnumerable<TaskQueryResultDto>?> IUnikService.GetAllTasksByUser(int projectId, string userId)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<TaskQueryResultDto>>($"api/Task/u/{projectId}/{userId}/");
        }

        
    }
}
