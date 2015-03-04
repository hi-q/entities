namespace Entities.Domain.Abstract.Pages
{
    public abstract class ProductsPageQuery : PageQuery
    {
        public long? SerialNumber { get; set; }
    }
}
