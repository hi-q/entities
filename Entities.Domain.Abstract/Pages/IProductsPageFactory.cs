using System.Collections.Generic;

namespace Entities.Domain.Abstract.Pages
{
    public interface IProductsPageFactory<out TProductsPage, in TProduct>
        where TProduct: IProduct
        where TProductsPage : Page<TProduct>
    {
        TProductsPage Page(IEnumerable<TProduct> products, int pageNum, int total);
    }
}
