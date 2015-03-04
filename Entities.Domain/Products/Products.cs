using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Entities.Domain.Abstract;
using Entities.Domain.Abstract.Repositories;
using Entities.Domain.Repositories;
using Product = Entities.Domain.Entities.Product;

namespace Entities.Domain.Products
{
    internal sealed class Products : ProductsBase, IProducts<Product>
    {
        private readonly IRepository<Product> _products;

        public Products(EntitiesContext db)
            : base(db)
        {
            _products = new ProductsRepository(db);
        }

        public Product Produce()
        {
            var product = _db.Products.Create();
            var addedProduct = _db.Products.Add(product);

            return addedProduct;
        }

        public Task<IEnumerable<Product>> ProduceAsync(ulong count)
        {
            return Task<IEnumerable<Product>>.Factory.StartNew(() =>
            {
                ICollection<Product> producedProducts = new Collection<Product>();

                while (count > 0)
                {
                    var product = Produce();
                    producedProducts.Add(product);

                    count -= 1;
                }

                SaveChanges();

                return producedProducts;
            });
        }

        public Task<IEnumerable<Product>> FilterAsync(long serialNumber)
        {
            return
                Task<IEnumerable<Product>>.Factory.StartNew(
                    () => _products.Query.Where(product => product.SerialNumber == serialNumber));
        }

        public Task<IEnumerable<Product>> FilterAsync(IEnumerable<long> serialNumbers)
        {
            return
                Task<IEnumerable<Product>>.Factory.StartNew(
                    () => _products.Query.Where(product => serialNumbers.Contains(product.SerialNumber)));
        }

        public Task DeleteAsync(IEnumerable<long> serialNumbers)
        {
            return Task.Factory.StartNew(() =>
            {
                _products.DeleteRange(serialNumbers);
                SaveChanges();
            });
        }

        public Product Add(Product product)
        {
            _products.Add(product);
            SaveChanges();

            return product;
        }

        public Task<IEnumerable<Product>> FetchAsync(IEnumerable<long> serialNumbers)
        {
            return Task<IEnumerable<Product>>.Factory.StartNew(() =>
            {
                return _products.Query
                    .Where(product => serialNumbers.Contains(product.SerialNumber))
                    .ToArray();
            });
        }
    }
}
