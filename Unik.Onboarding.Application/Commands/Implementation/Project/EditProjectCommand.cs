using Unik.Onboarding.Application.Commands.Onboarding;
using Unik.Onboarding.Application.Repositories;

namespace Unik.Onboarding.Application.Commands.Implementation.Onboarding;

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
        
        //DoIt
        model.Edit(requestDto.ProjectName, requestDto.RowVersion);

        //Save
        _repository.Update(model);
    }
}