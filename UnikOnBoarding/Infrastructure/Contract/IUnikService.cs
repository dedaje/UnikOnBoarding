using UnikOnBoarding.Infrastructure.Contract.Dto;

namespace UnikOnBoarding.Infrastructure.Contract
{
    public interface IUnikService
    {
        Task Create(OnboardingCreateRequestDto dto);
        Task Edit(OnboardingEditRequestDto dto);
        Task<OnboardingQueryResultDto> Get(int projectId);
        Task<IEnumerable<OnboardingQueryResultDto>> GetAll();
    }
}
