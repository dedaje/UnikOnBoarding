using System.Net.Http.Json;
using WebClient.UnikOnBoarding.Infrastructure.Contract;
using WebClient.UnikOnBoarding.Infrastructure.Contract.Dto.ProjectUsers;
using WebClient.UnikOnBoarding.Infrastructure.Contract.Dto.UserProjects;

namespace WebClient.UnikOnBoarding.Infrastructure.Implementation
{
    public class ProjectUsersService : IProjectUsersService
    {
        private readonly HttpClient _httpClient;

        public ProjectUsersService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        async Task IProjectUsersService.AddUserToProject(ProjectAddUserRequestDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/ProjectUsers/AddUserToProject", dto);

            if (response.IsSuccessStatusCode) return;

            var message = await response.Content.ReadAsStringAsync();
            throw new Exception(message);
        }

        async Task<IEnumerable<ProjectUsersQueryResultDto>?> IProjectUsersService.GetAllProjectUsers(int? projectId)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<ProjectUsersQueryResultDto>>($"api/ProjectUsers/{projectId}/");
        }

        async Task<IEnumerable<UserProjectsQueryResultDto>?> IProjectUsersService.GetAllUserProjects(string? userId)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<UserProjectsQueryResultDto>>($"api/ProjectUsers/{userId}/");
        }

        async Task IProjectUsersService.RemoveUserFromProject(string userId, int? projectId)
        {
            var response = await _httpClient.DeleteAsync($"api/ProjectUsers/RemoveUserFromProject/{userId}/{projectId}/");

            if (response.IsSuccessStatusCode) return;

            var message = await response.Content.ReadAsStringAsync();
            throw new Exception(message);
        }
    }
}
