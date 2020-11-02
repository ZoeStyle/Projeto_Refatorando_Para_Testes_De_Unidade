using store.Domain.Command.Interfaces;

namespace store.Domain.Handlers.interfaces
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}