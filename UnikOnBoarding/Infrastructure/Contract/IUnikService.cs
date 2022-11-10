using UnikOnBoarding.Infrastructure.Contract.Dto;

namespace UnikOnBoarding.Infrastructure.Contract
{
    public interface IUnikService
    {
        Task Create(OnboardingCreateRequestDto dto);
        Task Edit(OnboardingEditRequestDto dto);
        Task<OnboardingQueryResultDto> Get(int id, string identityName);
        Task<IEnumerable<OnboardingQueryResultDto>> GetAll(string identityName);
    }
}
