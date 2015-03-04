using System.Collections.Generic;
using System.Linq;
using Entities.Domain.Abstract;
using Entities.Domain.Abstract.Repositories;

namespace Entities.Domain.Repositories
{
    internal abstract class Repository<TProduct> : IRepository<TProduct>
        where TProduct : IProduct
    {
        protected EntitiesContext _db;

        protected Repository(EntitiesContext db)
        {
            _db = db;
        }

        public abstract TProduct Add(TProduct product);

        public abstract void Delete(TProduct product);

        public abstract void DeleteRange(IEnumerable<long> serialNumbers);

        public abstract void Save(TProduct product);

        public abstract IQueryable<TProduct> Query { get; }

        public int TotalCount
        {
            get { return Query.Count(); }
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}
