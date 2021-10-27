namespace Interfaces
{
    public interface IAttackable : IHealthHolder
    {
        void ReceiveDamage(int amount);
    }
}
