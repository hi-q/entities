using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Domain.Abstract.Common;
using Entities.Domain.Abstract.Entities.Produceable;

namespace Entities.Domain.Abstract
{
    public interface IProducts<TProduct> : 
        IProduceables<TProduct>,
        IAddable<TProduct>
        where TProduct : BaseProduct
    {
        Task DeleteAsync(IEnumerable<long> serialNumbers);

        Task<IEnumerable<TProduct>> ProduceAsync(ulong count);

        Task<IEnumerable<TProduct>> FilterAsync(long serialNumber);

        Task<IEnumerable<TProduct>> FilterAsync(IEnumerable<long> serialNumbers);

        Task<IEnumerable<TProduct>> FetchAsync(IEnumerable<long> serialNumbers);
    }
}
