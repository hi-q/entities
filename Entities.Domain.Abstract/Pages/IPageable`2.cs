using System.Threading.Tasks;

namespace Entities.Domain.Abstract.Pages
{
    public interface IPageable<in TPageQuery, TPage, TProduct>
        where TPageQuery : PageQuery
        where TPage : Page<TProduct>
        where TProduct : IProduct
    {
        Task<TPage> QueryPageAsync(TPageQuery pageQuery);

        int PagesCount(int rows);
    }
}
