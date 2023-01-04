using WebClient.UnikOnBoarding.Infrastructure.Contract.Dto.ProjectUsers;
using WebClient.UnikOnBoarding.Infrastructure.Contract.Dto.UserProjects;

namespace WebClient.UnikOnBoarding.Infrastructure.Contract;

public interface IProjectUsersService
{
    Task AddUserToProject(ProjectAddUserRequestDto dto);
    Task<IEnumerable<ProjectUsersQueryResultDto>?> GetAllProjectUsers(int? projectId);
    Task<IEnumerable<UserProjectsQueryResultDto>?> GetAllUserProjects(string? userId);
    Task RemoveUserFromProject(string userId, int? projectId);
}