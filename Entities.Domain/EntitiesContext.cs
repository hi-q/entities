using System.Configuration;
using System.Data.Entity;
using System.Diagnostics;
using Entities.Domain.Entities;

namespace Entities.Domain
{
    public class EntitiesContext : DbContext
    {
        private static string _connectionString
        {
            get { return ConfigurationManager.ConnectionStrings["Entities"].ConnectionString; }
        }

        public EntitiesContext() : base(_connectionString)
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<EntitiesContext>());
#if DEBUG
            Database.Log = s => Debug.Write(s);
#endif
        }

        public EntitiesContext(bool test)
        {
            
        }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<ExploitedProduct> ExploitedProducts { get; set; }
    }
}
