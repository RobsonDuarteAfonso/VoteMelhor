using VoteMelhor.Domain.Interfaces.Commands;

namespace VoteMelhor.Domain.Interfaces.Handlers
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}