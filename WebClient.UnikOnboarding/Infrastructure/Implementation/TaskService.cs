using System.Net.Http.Json;
using WebClient.UnikOnBoarding.Infrastructure.Contract;
using WebClient.UnikOnBoarding.Infrastructure.Contract.Dto.Task;

namespace WebClient.UnikOnBoarding.Infrastructure.Implementation
{
    public class TaskService : ITaskService
    {
        private readonly HttpClient _httpClient;

        public TaskService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        async Task ITaskService.CreateTask(TaskCreateRequestDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/Task/CreateTask/", dto);

            if (response.IsSuccessStatusCode) return;

            var message = await response.Content.ReadAsStringAsync();
            throw new Exception(message);
        }

        async Task<IEnumerable<TaskQueryResultDto>?> ITaskService.GetAllTasks(int projectId)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<TaskQueryResultDto>>($"api/Task/AllTasks/{projectId}/");
        }

        async Task<TaskQueryResultDto?> ITaskService.GetTask(int taskId)
        {
            return await _httpClient.GetFromJsonAsync<TaskQueryResultDto>($"api/Task/{taskId}/");
        }

        async Task ITaskService.EditTask(TaskEditRequestDto dto)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Task/EditTask/", dto);

            if (response.IsSuccessStatusCode) return;

            var message = await response.Content.ReadAsStringAsync();
            throw new Exception(message);
        }

        async Task ITaskService.DeleteTask(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Task/DeleteTask/{id}/");

            if (response.IsSuccessStatusCode) return;

            var message = await response.Content.ReadAsStringAsync();
            throw new Exception(message);
        }
    }
}
