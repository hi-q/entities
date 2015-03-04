namespace Entities.Domain.Products
{
    internal abstract class ProductsBase
    {
        protected readonly EntitiesContext _db;


        protected ProductsBase(EntitiesContext db)
        {
            _db = db;
        }

        protected void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}
