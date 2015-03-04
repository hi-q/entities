namespace Entities.Domain.Abstract.Common
{
    public interface IQueryable<out TProduct>
        where TProduct : IProduct
    {
        System.Linq.IQueryable<TProduct> Query { get;  }
    }
}
