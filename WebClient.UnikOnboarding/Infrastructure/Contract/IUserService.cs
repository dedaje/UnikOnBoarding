using WebClient.UnikOnBoarding.Infrastructure.Contract.Dto.User;

namespace WebClient.UnikOnBoarding.Infrastructure.Contract;

public interface IUserService
{
    Task CreateUser(UserCreateRequestDto dto);
    Task<IEnumerable<UserQueryResultDto>?> GetAllUsers();
    Task<UserQueryResultDto> GetUser(string userId);
    Task DeleteUser(string userId);
}