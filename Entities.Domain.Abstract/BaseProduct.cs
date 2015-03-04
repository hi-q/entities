namespace Entities.Domain.Abstract
{
    public abstract class BaseProduct : IProduct
    {
        public abstract long SerialNumber { get; set; }

        public abstract string Description { get; set; }
    }
}
