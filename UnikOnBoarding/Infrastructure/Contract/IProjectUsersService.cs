using UnikOnBoarding.Infrastructure.Contract.Dto.ProjectUsers;
using UnikOnBoarding.Infrastructure.Contract.Dto.UserProjects;

namespace UnikOnBoarding.Infrastructure.Contract
{
    public interface IProjectUsersService
    {
        Task AddUserToProject(ProjectAddUserRequestDto dto);
        Task<IEnumerable<ProjectUsersQueryResultDto>?> GetAllProjectUsers(int? projectId);
        Task<IEnumerable<UserProjectsQueryResultDto>?> GetAllUserProjects(string? userId);
        Task RemoveUserFromProject(string userId, int? projectId);
    }
}
