using Unik.Onboarding.Application.Commands.Task;
using Unik.Onboarding.Application.Repositories;
using Unik.Onboarding.Domain.Model;

namespace Unik.Onboarding.Application.Commands.Implementation.Task;

public class CreateTaskCommand : ICreateTaskCommand
{
    private readonly ITaskRepository _repository;

    public CreateTaskCommand(ITaskRepository repository)
    {
        _repository = repository;
    }

    void ICreateTaskCommand.Create(TaskCreateRequestDto request)
    {
        var task = new TaskEntity(request.TaskName, request.TaskDescription, request.ProjectsId, request.Section, request.UsersId);
        _repository.AddTask(task);

        //throw new NotImplementedException();
    }
}