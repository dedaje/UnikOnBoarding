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
           var response = await _httpClient.PostAsJsonAsync($"api/Project/Create", dto);

           if (response.IsSuccessStatusCode) return;

           var message = await response.Content.ReadAsStringAsync();
           throw new Exception(message);
        }

        async Task IUnikService.Edit(ProjectEditRequestDto dto)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Project/Edit", dto);

            if (response.IsSuccessStatusCode) return;

            var messege = await response.Content.ReadAsStringAsync();
            throw new Exception(messege);
        }

        async Task<ProjectQueryResultDto?> IUnikService.GetProject(string userId, int projectId)
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
    }
}
