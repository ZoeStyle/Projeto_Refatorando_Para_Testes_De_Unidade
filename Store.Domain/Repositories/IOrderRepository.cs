using store.Domain.Entities;

namespace store.Domain.Repositories
{
    public interface IOrderRepository
    {
        void Save(Order order);
    }
}