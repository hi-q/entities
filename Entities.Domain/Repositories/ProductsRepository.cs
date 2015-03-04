using System.Data.Entity.Migrations;
using System.Linq;
using Entities.Domain.Entities;

namespace Entities.Domain.Repositories
{
    internal sealed class ProductsRepository : Repository<Product>
    {
        public ProductsRepository(EntitiesContext db) : base(db)
        {
        }

        public override Product Add(Product product)
        {
            return _db.Products.Add(product);
        }

        public override void Delete(Product product)
        {
            DeleteRange(new [] { product.SerialNumber});
        }

        public override void Save(Product product)
        {
            _db.Products.AddOrUpdate(product);
        }

        public override IQueryable<Product> Query
        {
            get
            {
                return _db.Products;
            }
        }

        public override void DeleteRange(System.Collections.Generic.IEnumerable<long> serialNumbers)
        {
            _db.Products.RemoveRange(_db.Products.Where(product => serialNumbers.Contains(product.SerialNumber)));
        }
    }
}
