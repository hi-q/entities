using System.Collections.Generic;

namespace Entities.Domain.Abstract.Common
{
    public interface IDeletable<in TProduct>
        where TProduct : IProduct
    {
        void Delete(TProduct product);

        void DeleteRange(IEnumerable<long> serialNumbers);
    }
}
