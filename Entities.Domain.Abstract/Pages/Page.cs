using System.Collections.Generic;

namespace Entities.Domain.Abstract.Pages
{
    public abstract class Page<TProduct>
        where TProduct : IProduct
    {
        protected Page(IEnumerable<TProduct> products, int pageNum, int total)
        {
            Items = products;
            PageNum = pageNum;
            Total = total;
        }

        public IEnumerable<TProduct> Items { get; protected set; }

        public int PageNum { get; protected set; }

        public int Total { get; protected set; }
    }
}
