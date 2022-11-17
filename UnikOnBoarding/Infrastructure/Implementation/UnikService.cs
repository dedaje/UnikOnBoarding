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

        async Task IUnikService.Create(OnboardingCreateRequestDto dto)
        {
            await _httpClient.PostAsJsonAsync($"api/Onboarding/", dto);
        }

        async Task IUnikService.Edit(OnboardingEditRequestDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/Onboarding/", dto);
            if (response.IsSuccessStatusCode) return;

            var messege = await response.Content.ReadAsStringAsync();
            throw new Exception(messege);
        }

        async Task<OnboardingQueryResultDto> IUnikService.Get(int projectId)
        {
            return await _httpClient.GetFromJsonAsync<OnboardingQueryResultDto>($"api/Onboarding/{projectId}/");
        }

        async Task<IEnumerable<OnboardingQueryResultDto>> IUnikService.GetAll()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<OnboardingQueryResultDto>>($"api/Onboarding/");
        }
    }
}
