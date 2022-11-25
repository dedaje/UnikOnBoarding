namespace Unik.Onboarding.Application.Queries.Project;

public interface IProjectGetAllQuery
{
    //Gets all the projects that the logged in user is assigned to
    IEnumerable<ProjectQueryResultDto> GetAllProjects(string userId); // This GetAll needs the userId of the user that's logged in currently
}