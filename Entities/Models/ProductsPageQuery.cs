using DomainPageQuery = Entities.Domain.Pages.ProductsPageQuery;

namespace Entities.Models
{
    public class ProductsPageQuery : PageQuery
    {
        public long? SerialNumber { get; set; }

        public DomainPageQuery ToDomainPageQuery()
        {
            var domainPageQuery = new DomainPageQuery
            {
                SerialNumber = SerialNumber,
                Page = Page,
                Rows = Rows
            };

            return domainPageQuery;
        }
    }
}