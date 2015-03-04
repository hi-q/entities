using Entities.Domain.Abstract.Entities.Exploitable;
using Entities.Domain.Abstract.Entities.Produceable;

namespace Entities.Domain.Abstract
{
    public interface IProduct : IProduceable, IExploitable
    {
        long SerialNumber { get; }
        string Description { get; }
    }
}
