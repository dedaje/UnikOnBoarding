using UnikOnBoarding.Infrastructure.Contract;
using UnikOnBoarding.Infrastructure.Contract.Dto.Task;

namespace UnikOnBoarding.Infrastructure.Implementation
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
            var response = await _httpClient.PostAsJsonAsync($"api/Task/Create", dto);

            if (response.IsSuccessStatusCode) return;

            var message = await response.Content.ReadAsStringAsync();
            throw new Exception(message);
        }

        async Task<IEnumerable<TaskQueryResultDto>?> ITaskService.GetAllTasks(int projectId)
        {
            throw new NotImplementedException();
        }

        async Task<TaskQueryResultDto?> ITaskService.GetTask(int taskId)
        {
            throw new NotImplementedException();
        }

        async Task ITaskService.EditTask(TaskEditRequestDto dto)
        {
            throw new NotImplementedException();
        }

        async Task ITaskService.DeleteTask(int id)
        {
            throw new NotImplementedException();
        }
    }
}
