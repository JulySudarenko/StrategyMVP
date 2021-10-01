namespace Interfaces
{
    public interface IAttackCommand : ICommand
    {
        public IAttacked Target { get; }
    }
}
