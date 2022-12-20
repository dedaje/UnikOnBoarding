using UnikOnBoarding.Infrastructure.Contract.Dto.User;

namespace UnikOnBoarding.Infrastructure.Contract
{
    public interface IUserService
    {
        Task CreateUser(UserCreateRequestDto dto);
        Task<IEnumerable<UserQueryResultDto>?> GetAllUsers();
        Task<UserQueryResultDto> GetUser(string userId);
        Task DeleteUser(int id);
    }
}
