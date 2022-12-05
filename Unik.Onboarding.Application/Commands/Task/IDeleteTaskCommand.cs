namespace Unik.Onboarding.Application.Commands.Task;

public interface IDeleteTaskCommand
{
    void Delete(TaskDeleteRequestDto request);
}