using DomainProduct = Entities.Domain.Entities.Product;

namespace Entities.Models
{
    public class Product
    {
        public long SerialNumber { get; set; }

        public string Description { get; set; }

        public Product() { }

        public Product(DomainProduct product)
        {
            SerialNumber = product.SerialNumber;
            Description = product.Description;
        }

        public DomainProduct ToDomainProduct()
        {
            var domainProduct = new DomainProduct(SerialNumber)
            {
                Description = Description
            };

            return domainProduct;
        }
    }
}