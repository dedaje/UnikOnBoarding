﻿using System;
using System.Threading.Tasks;
using UnikOnBoarding.Infrastructure.Contract;
using UnikOnBoarding.Infrastructure.Contract.Dto;

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
        async Task IUnikService.Create(ProjectCreateRequestDto dto)
        {
           var response = await _httpClient.PostAsJsonAsync($"api/Project/Create", dto);

           if (response.IsSuccessStatusCode) return;

           var message = await response.Content.ReadAsStringAsync();
           throw new Exception(message);
        }

        async Task IUnikService.Edit(ProjectEditRequestDto dto)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Project/Edit", dto);

            if (response.IsSuccessStatusCode) return;

            var message = await response.Content.ReadAsStringAsync();
            throw new Exception(message);
        }

        async Task IUnikService.Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Project/DeleteProject/{id}/");

            if (response.IsSuccessStatusCode) return;

            var message = await response.Content.ReadAsStringAsync();
            throw new Exception(message);
        }

        async Task<ProjectQueryResultDto?> IUnikService.GetProject(string userId, int? projectId)
        {
            return await _httpClient.GetFromJsonAsync<ProjectQueryResultDto>($"api/Project/{userId}/{projectId}/");
        }

        async Task<IEnumerable<ProjectQueryResultDto>?> IUnikService.GetAllUserProjects(string userId)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<ProjectQueryResultDto>>($"api/Project/u/{userId}/");
        }

        async Task<IEnumerable<ProjectQueryResultDto>?> IUnikService.GetAllEditProjects(int? projectId)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<ProjectQueryResultDto>>($"api/Project/p/{projectId}/");
        }

        // User
        async Task IUnikService.AddUser(AddUserRequestDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/User/AddUser", dto);

            if (response.IsSuccessStatusCode) return;

            var message = await response.Content.ReadAsStringAsync();
            throw new Exception(message);
        }

        async Task IUnikService.RemoveUser(string userId, int? projectId)
        {
            var response = await _httpClient.DeleteAsync($"api/User/RemoveUser/{userId}/{projectId}/");
            
            if (response.IsSuccessStatusCode) return;

            var message = await response.Content.ReadAsStringAsync();
            throw new Exception(message);
        }

        // Task
        async Task IUnikService.CreateTask(TaskCreateRequestDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/Task/Create", dto);

            if (response.IsSuccessStatusCode) return;

            var message = await response.Content.ReadAsStringAsync();
            throw new Exception(message);
        }

        async Task IUnikService.DeleteTask(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Task/DeleteTask/{id}/");

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
