namespace Unik.Onboarding.Application.Commands.Task;

public interface ICreateTaskCommand
{
    void Create(TaskCreateRequestDto request);
}