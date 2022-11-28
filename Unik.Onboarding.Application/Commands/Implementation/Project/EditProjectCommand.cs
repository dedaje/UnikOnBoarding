using Unik.Onboarding.Application.Commands.Project;
using Unik.Onboarding.Application.Repositories;

namespace Unik.Onboarding.Application.Commands.Implementation.Project;

public class EditProjectCommand : IEditProjectCommand
{
    private readonly IProjectRepository _repository;

    public EditProjectCommand(IProjectRepository repository)
    {
        _repository = repository;
    }

    void IEditProjectCommand.Edit(ProjectEditRequestDto requestDto)
    {
        //Read
        var model = _repository.Load(requestDto.ProjectId);

        //do
        //{
            //DoIt
            model.Edit(requestDto.ProjectName, requestDto.RowVersion);

            //Save
            _repository.Update(model);
        //}
        //while (model != null);
    }
}