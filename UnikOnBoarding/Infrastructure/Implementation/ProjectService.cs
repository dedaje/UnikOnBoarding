using UnikOnBoarding.Infrastructure.Contract;
using UnikOnBoarding.Infrastructure.Contract.Dto.Project;
using UnikOnBoarding.Infrastructure.Contract.Dto.ProjectUsers;

namespace UnikOnBoarding.Infrastructure.Implementation
{
    public class ProjectService : IProjectService
    {
        private readonly HttpClient _httpClient;

        public ProjectService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        async Task IProjectService.CreateProject(ProjectCreateWithUserRequestDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/Project/CreateProject", dto);

            if (response.IsSuccessStatusCode) return;

            var message = await response.Content.ReadAsStringAsync();
            throw new Exception(message);
        }

        async Task<IEnumerable<ProjectQueryResultDto>?> IProjectService.GetAllProjects()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<ProjectQueryResultDto>>($"api/Project/AllProjects/");
        }

        async Task<ProjectQueryResultDto?> IProjectService.GetProject(int? projectId)
        {
            return await _httpClient.GetFromJsonAsync<ProjectQueryResultDto>($"api/Project/{projectId}/");
        }

        async Task IProjectService.EditProject(ProjectEditRequestDto dto)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Project/EditProject", dto);

            if (response.IsSuccessStatusCode) return;

            var message = await response.Content.ReadAsStringAsync();
            throw new Exception(message);
        }

        async Task IProjectService.DeleteProject(int projectId)
        {
            var response = await _httpClient.DeleteAsync($"api/Project/DeleteProject/{projectId}/");

            if (response.IsSuccessStatusCode) return;

            var message = await response.Content.ReadAsStringAsync();
            throw new Exception(message);
        }
    }
}
