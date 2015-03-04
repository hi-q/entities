using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Entities.Models;
using Product = Entities.Domain.Entities.Product;
using Products = Entities.Domain.Abstract.IProducts<Entities.Domain.Entities.Product>;

using PageableProducts = Entities.Domain.Abstract.Pages.PageableProducts<Entities.Domain.Pages.ProductsPageQuery, Entities.Domain.Pages.ProductsPage, Entities.Domain.Entities.Product>;

using ProductsPageQuery = Entities.Models.ProductsPageQuery;
using UiProduct = Entities.Models.Product;

namespace Entities.Controllers
{
    public class ProductsController : Controller
    {
        private readonly Products _products;

        private readonly PageableProducts _pageableProducts;

        public ProductsController(Products products, PageableProducts pageableProducts)
        {
            _products = products;
            _pageableProducts = pageableProducts;
        }

        [HttpPost]
        public JsonResult Add(UiProduct product)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.Forbidden;
                Response.StatusDescription = "Model is invalid";

                return Json(new {});
            }

            var productToAdd = product.ToDomainProduct();
            _products.Add(productToAdd);

            return Json(productToAdd);
        }

        [HttpPost]
        public async Task<JsonResult> PageAsync(ProductsPageQuery pageQuery)
        {
            var query = pageQuery.ToDomainPageQuery();
            var productsPage = await _pageableProducts.QueryPageAsync(query);

            return Json(productsPage);
        }

        [HttpGet]
        public async Task<JsonResult> ProduceAsync(ulong count)
        {
            var producedProducts = await _products.ProduceAsync(count);
            var uiProducts = ToUiProducts(producedProducts);
            return Json(uiProducts, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<HttpStatusCodeResult> DeleteAsync(DeleteProductsQuery deleteQuery)
        {
            await _products.DeleteAsync(deleteQuery.ProductsIds);

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        private static IEnumerable<UiProduct> ToUiProducts(IEnumerable<Product> products)
        {
            IEnumerable<UiProduct> uiProducts = products
                    .Select(product => new UiProduct(product))
                    .ToArray();

            return uiProducts;    
        }
    }
}