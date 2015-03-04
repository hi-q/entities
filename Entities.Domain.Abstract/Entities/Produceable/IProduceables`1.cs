namespace Entities.Domain.Abstract.Entities.Produceable
{
    public interface IProduceables<out TProduceable>
        where TProduceable : IProduceable
    {
        TProduceable Produce();
    }
}
