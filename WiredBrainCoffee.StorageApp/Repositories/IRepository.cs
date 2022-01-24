using WiredBrainCoffee.StorageApp.Entities;

namespace WiredBrainCoffee.StorageApp.Repositories
{
    public interface IRepository<TItem> where TItem : IEntity
    {
        void Add(TItem item);
        TItem GetById(int id);
        void Remove(TItem item);
        void Save();
    }
}