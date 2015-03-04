using Entities.Domain.Abstract;
using Entities.Domain.Abstract.Entities;
using Entities.Domain.Abstract.Entities.Exploitable;
using Entities.Domain.Abstract.Pages;
using Entities.Domain.Abstract.Repositories;
using Entities.Domain.Entities;
using Entities.Domain.Pages;
using Entities.Domain.Products;
using Entities.Domain.Repositories;
using Ninject;

using Product = Entities.Domain.Entities.Product;
using ExploitedProduct = Entities.Domain.Entities.ExploitedProduct;

namespace Entities.Domain.IoC
{
    public sealed class DependencyResolver
    {
        private readonly IKernel _kernel;

        public DependencyResolver(IKernel kernel)
        {
            _kernel = kernel;
        }

        public void RegisterServices()
        {
            _kernel.Bind<IProduct>().To<Product>();
            _kernel.Bind<IProductsPageFactory<ProductsPage, Product>>().To<ProductsPageFactory>();
            _kernel.Bind<IProductsPageFactory<ExploitedProductsPage, ExploitedProduct>>().To<ExploitedProductsPageFactory>();
            
            _kernel.Bind<IProducts<Product>>().To<Products.Products>();
            
            _kernel
                .Bind<PageableProducts<Pages.ProductsPageQuery, ProductsPage, Product>>()
                .To<PageableProducts>();

            _kernel
                .Bind<PageableProducts<Pages.ProductsPageQuery, ExploitedProductsPage, ExploitedProduct>>()
                .To<PageableExploitedProducts>();

            _kernel.Bind<IRepository<Product>>().To<ProductsRepository>();
            _kernel.Bind<IExploitedProducts>().To<ExploitedProducts>();
            _kernel.Bind<IRepository<ExploitedProduct>>().To<ExploitedProductsRepository>();

            _kernel.Bind<IReporter>().To<Reporter>();
        }
    }
}
