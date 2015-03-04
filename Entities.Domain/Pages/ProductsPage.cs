using System.Collections.Generic;
using Entities.Domain.Entities;

namespace Entities.Domain.Pages
{
    public class ProductsPage : Abstract.Pages.Page<Product>
    {
        public ProductsPage(IEnumerable<Product> products, int pageNum, int total)
            : base(products, pageNum, total)
        {
        }
    }
}
