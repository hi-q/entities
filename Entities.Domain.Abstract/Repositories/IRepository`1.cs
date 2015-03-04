using Entities.Domain.Abstract.Common;

namespace Entities.Domain.Abstract.Repositories
{
    public interface IRepository<TProduct> : 
        IQueryable<TProduct>,
        IAddable<TProduct>,
        IDeletable<TProduct>,
        ISavable<TProduct>
        where TProduct : IProduct
    {
        void SaveChanges();
    }
}
