namespace Entities.Domain.Abstract.Common
{
    public interface IAddable<TProduct>
        where TProduct : IProduct
    {
        TProduct Add(TProduct product);
    }
}
