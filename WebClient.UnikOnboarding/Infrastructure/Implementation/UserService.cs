using System.Net.Http.Json;
using WebClient.UnikOnBoarding.Infrastructure.Contract;
using WebClient.UnikOnBoarding.Infrastructure.Contract.Dto.User;

namespace WebClient.UnikOnBoarding.Infrastructure.Implementation
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        async Task IUserService.CreateUser(UserCreateRequestDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/User/CreateUser", dto);

            if (response.IsSuccessStatusCode) return;

            var message = await response.Content.ReadAsStringAsync();
            throw new Exception(message);
        }

        async Task<IEnumerable<UserQueryResultDto>?> IUserService.GetAllUsers()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<UserQueryResultDto>>($"api/User/AllUsers/");
        }

        async Task<UserQueryResultDto> IUserService.GetUser(string userId)
        {
            return await _httpClient.GetFromJsonAsync<UserQueryResultDto>($"api/User/{userId}/");
        }

        async Task IUserService.DeleteUser(string userId)
        {
            var response = await _httpClient.DeleteAsync($"api/User/DeleteUser/{userId}/");

            if (response.IsSuccessStatusCode) return;

            var message = await response.Content.ReadAsStringAsync();
            throw new Exception(message);
        }
    }
}
