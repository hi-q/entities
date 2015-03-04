using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Entities.Domain.Entities;
using Entities.Tests.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Entities.Domain.Tests
{
    [TestClass]
    public class ReporterTest
    {
        private Reporter _reporter;

        private Mock<DbSet<Product>> _productsMock;
        private Mock<DbSet<ExploitedProduct>> _exploitedProductsMock;

        [TestInitialize]
        public void Setup()
        {
            _productsMock = new Mock<DbSet<Product>>();
            _productsMock.Mock();

            _exploitedProductsMock = new Mock<DbSet<ExploitedProduct>>();
            _exploitedProductsMock.Mock();

            const bool test = true;
            var ctx = new Mock<EntitiesContext>(MockBehavior.Loose, test);

            ctx.Setup(ec => ec.Products).Returns(_productsMock.Object);
            ctx.Setup(ec => ec.ExploitedProducts).Returns(_exploitedProductsMock.Object);

            _reporter = new Reporter(ctx.Object);
        }

        [TestCleanup]
        public void TearDown()
        {
            _productsMock = null;
            _exploitedProductsMock = null;
            _reporter = null;
        }

        [TestMethod]
        [Description("Should fetch when have some produced and some exploited")]
        public async Task FetchRemainsSerialNumbersAsync()
        {
            var products = new[]
            {
                new Product {SerialNumber = 1, Description = ""},
                new Product {SerialNumber = 2, Description = "descr"},
            };
            Array.ForEach(products, product => _productsMock.Object.Add(product));

            var exploitedProducts = new[]
            {
                new ExploitedProduct(products.First())
            };
            Array.ForEach(exploitedProducts, ep => _exploitedProductsMock.Object.Add(ep));

            var remainedSerialNumbersQueryable = await _reporter.FetchRemainsSerialNumbersAsync();
            var remainedSerialNumbers = remainedSerialNumbersQueryable.ToArray();

            Assert.IsNotNull(remainedSerialNumbers, "should not be null");
            Assert.IsTrue(remainedSerialNumbers.Count() == 1);
            Assert.AreEqual(remainedSerialNumbers[0], 2);
        }
    }
}
