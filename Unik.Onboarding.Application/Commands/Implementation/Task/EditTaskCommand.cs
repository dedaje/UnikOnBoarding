using Unik.Onboarding.Application.Commands.Task;
using Unik.Onboarding.Application.Repositories;

namespace Unik.Onboarding.Application.Commands.Implementation.Task;

public class EditTaskCommand : IEditTaskCommand
{
    private readonly ITaskRepository _repository;

    public EditTaskCommand(ITaskRepository repository)
    {
        _repository = repository;
    }

    void IEditTaskCommand.Edit(TaskEditRequestDto request)
    {
        ////Read
        //var model = _repository.Load(request.TaskId);

        ////DoIt
        //model.Edit(request.TaskName, request.TaskDescription/*, request.RowVersion*/);

        ////Save
        //_repository.Update(model);

        throw new NotImplementedException();
    }
}