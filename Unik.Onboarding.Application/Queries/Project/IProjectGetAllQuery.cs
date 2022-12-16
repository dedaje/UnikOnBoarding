namespace Unik.Onboarding.Application.Queries.Project;

public interface IProjectGetAllQuery
{
    IEnumerable<ProjectQueryResultDto> GetAllProjects();
}