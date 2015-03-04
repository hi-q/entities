using Entities.Domain.Abstract.Pages;
using Entities.Domain.Abstract.Repositories;
using Entities.Domain.Entities;

namespace Entities.Domain.Pages
{
    internal class PageableProducts : PageableProducts<ProductsPageQuery, ProductsPage, Product>
    {
        public PageableProducts(
            IRepository<Product> products, 
            IProductsPageFactory<ProductsPage, Product> productsPageFactory)
            : base(products, productsPageFactory)
        {
        }
    }
}
