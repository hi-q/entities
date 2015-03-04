using System.Linq;
using System.Threading.Tasks;
using Entities.Domain.Abstract.Repositories;

namespace Entities.Domain.Abstract.Pages
{
    public abstract class PageableProducts<TProductsPageQuery, TProductsPage, TProduct> :
        Pageable<TProductsPageQuery, TProductsPage, TProduct>
        
        where TProductsPageQuery : ProductsPageQuery
        where TProduct : BaseProduct
        where TProductsPage : Page<TProduct>
    {
        protected PageableProducts(
            IRepository<TProduct> products,
            IProductsPageFactory<TProductsPage, TProduct> productsPageFactory)
            : base(products, productsPageFactory)
        {
        }

        public override Task<TProductsPage> QueryPageAsync(TProductsPageQuery pageQuery)
        {
            return Task<TProductsPage>.Factory.StartNew(() =>
            {
                var pageNum = pageQuery.Page;
                var rows = pageQuery.Rows;
                var skip = (pageNum - 1) * rows;

                var products = _products.Query;

                if (pageQuery.SerialNumber.HasValue)
                {
                    var serialNumber = pageQuery.SerialNumber.Value;
                    products = products.Where(product => product.SerialNumber == serialNumber);
                }

                products = products.OrderBy(product => product.SerialNumber)
                    .Skip(skip)
                    .Take(rows);

                // This better to be in the same transaction, actually we do not need this for now.
                var total = PagesCount(rows);

                var page = _productsPageFactory.Page(products.ToArray(), pageNum, total);
                return page;
            });
        }
    }
}
