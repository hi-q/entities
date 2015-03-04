using System.Collections.Generic;
using Entities.Domain.Abstract.Pages;
using Entities.Domain.Entities;

namespace Entities.Domain.Pages
{
    internal class ProductsPageFactory : IProductsPageFactory<ProductsPage, Product>
    {
        public ProductsPage Page(IEnumerable<Product> products, int pageNum, int total)
        {
            return new ProductsPage(products, pageNum, total);
        }
    }
}
