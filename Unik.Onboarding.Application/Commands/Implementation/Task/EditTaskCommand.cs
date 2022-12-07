using System.Data;
using Unik.Crosscut.TransactionHandling;
using Unik.Onboarding.Application.Commands.Task;
using Unik.Onboarding.Application.Repositories;

namespace Unik.Onboarding.Application.Commands.Implementation.Task;

public class EditTaskCommand : IEditTaskCommand
{
    private readonly ITaskRepository _repository;
    private readonly IUnitOfWork _uow;

    public EditTaskCommand(ITaskRepository repository, IUnitOfWork uow)
    {
        _repository = repository;
        _uow = uow;
    }

    void IEditTaskCommand.Edit(TaskEditRequestDto request)
    {
        
       
        try
        {
            _uow.BeginTransaction(IsolationLevel.Serializable);
             //Read
            var model = _repository.Load(request.TaskId);
            //DoIt
            model.Edit(request.TaskName, request.TaskDescription/*, request.RowVersion*/);
            //Save
            _repository.Update(model);

            _uow.Commit();
        }
        catch
        {
            _uow.Rollback();
            throw;
        }


       
    }
}