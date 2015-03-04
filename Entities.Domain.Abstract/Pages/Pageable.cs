using System.Linq;
using System.Threading.Tasks;
using Entities.Domain.Abstract.Repositories;

namespace Entities.Domain.Abstract.Pages
{
    public abstract class Pageable<TProductsPageQuery, TProductsPage, TProduct> :
        IPageable<TProductsPageQuery, TProductsPage, TProduct>
        where TProductsPageQuery : PageQuery
        where TProduct : BaseProduct
        where TProductsPage : Page<TProduct>
    {
        protected readonly IRepository<TProduct> _products;

        protected readonly IProductsPageFactory<TProductsPage, TProduct> _productsPageFactory;

        protected Pageable(IRepository<TProduct> products, IProductsPageFactory<TProductsPage, TProduct> productsPageFactory)
        {
            _products = products;
            _productsPageFactory = productsPageFactory;
        }

        public abstract Task<TProductsPage> QueryPageAsync(TProductsPageQuery pageQuery);

        public int PagesCount(int rows)
        {
            var productsCount = _products.Query.Count();
            var fullPages = productsCount / rows;
            var extraItems = productsCount % rows;
            if (extraItems > 0)
            {
                fullPages += 1;
            }

            return fullPages;
        }
    }
}