namespace Entities.Domain.Abstract.Common
{
    public interface ISavable<in TProduct>
    {
        void Save(TProduct product);
    }
}
