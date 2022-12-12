using Unik.Onboarding.Application.Queries.ProjectUsers;
using Unik.Onboarding.Application.Queries.UserProjects;

namespace Unik.Onboarding.Application.Queries.Project;

public interface IProjectGetAllQuery
{
    IEnumerable<ProjectUsersQueryResultDto> GetAllProjectUsers(int projectId); // Gets all the users that is assigned to specific project
    IEnumerable<ProjectQueryResultDto> GetAllProjects();
}