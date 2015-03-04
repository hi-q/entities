using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Domain.Abstract.Entities;
using Entities.Domain.Repositories;

namespace Entities.Domain
{
    internal sealed class Reporter : IReporter
    {
        private readonly ProductsRepository _productsRepository;

        private readonly ExploitedProductsRepository _exploitedProductsRepository;

        public Reporter(EntitiesContext db)
        {
            _productsRepository = new ProductsRepository(db);
            _exploitedProductsRepository = new ExploitedProductsRepository(db);
        }

        public Task<IEnumerable<long>> FetchRemainsSerialNumbersAsync()
        {
            return Task<IEnumerable<long>>.Factory.StartNew(() =>
            {
                var exploitProductsSerialNumbers = _exploitedProductsRepository.Query
                    .Select(product => product.SerialNumber)
                    .ToList();

                var remainsSerialNumbers = _productsRepository.Query
                    .Where(product => !exploitProductsSerialNumbers.Contains(product.SerialNumber))
                    .Select(product => product.SerialNumber).ToArray();

                return remainsSerialNumbers;
            });
        }
    }
}
