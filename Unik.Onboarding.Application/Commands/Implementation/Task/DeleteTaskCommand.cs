using Unik.Onboarding.Application.Commands.Task;
using Unik.Onboarding.Application.Repositories;

namespace Unik.Onboarding.Application.Commands.Implementation.Task;

public class DeleteTaskCommand : IDeleteTaskCommand
{
    private readonly ITaskRepository _repository;

    public DeleteTaskCommand(ITaskRepository repository)
    {
        _repository = repository;
    }

    void IDeleteTaskCommand.Delete(int id)
    {
        var model = _repository.LoadTask(id);

        _repository.DeleteTask(model);

        //throw new NotImplementedException();
    }
}