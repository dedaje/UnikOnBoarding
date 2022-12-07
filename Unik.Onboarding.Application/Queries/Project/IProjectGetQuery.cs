namespace Unik.Onboarding.Application.Queries.Project;

public interface IProjectGetQuery
{
    ProjectQueryResultDto GetProject(int projectId); 
}