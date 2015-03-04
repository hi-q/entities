using System.Collections.Generic;
using System.Threading.Tasks;

namespace Entities.Domain.Abstract.Entities
{
    public interface IReporter
    {
        Task<IEnumerable<long>> FetchRemainsSerialNumbersAsync();
    }
}
