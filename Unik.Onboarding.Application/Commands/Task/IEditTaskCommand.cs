namespace Unik.Onboarding.Application.Commands.Task;

public interface IEditTaskCommand
{
    void Edit(TaskEditRequestDto request);
}