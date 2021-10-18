namespace Interfaces
{
    public interface ICommandsQueue
    {
        void EnqueueCommand(object command);
        void Clear();
    }
}
