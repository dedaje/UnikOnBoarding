namespace Unik.Onboarding.Application.Queries.Project;

public interface IProjectGetQuery
{
    ProjectQueryResultDto GetProject(string userId, int projectId); // This Gets a logged in user's specific project they're assigned to
}