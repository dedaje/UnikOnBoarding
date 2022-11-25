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

        async Task IUnikService.Create(ProjectCreateRequestDto dto)
        {
            await _httpClient.PostAsJsonAsync($"api/Project", dto);
        }

        async Task IUnikService.Edit(ProjectEditRequestDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/Project", dto);
            if (response.IsSuccessStatusCode) return;

            var messege = await response.Content.ReadAsStringAsync();
            throw new Exception(messege);
        }

        async Task<ProjectQueryResultDto?> IUnikService.GetProject(string userId, int projectId)
        {
            return await _httpClient.GetFromJsonAsync<ProjectQueryResultDto>($"api/Project/{userId}/{projectId}/");
        }

        async Task<IEnumerable<ProjectQueryResultDto>?> IUnikService.GetAllProjects(string userId)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<ProjectQueryResultDto>>($"api/Project/{userId}/");
        }
    }
}
