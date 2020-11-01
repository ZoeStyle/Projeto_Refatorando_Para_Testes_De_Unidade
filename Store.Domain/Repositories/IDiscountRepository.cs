using store.Domain.Entities;

namespace store.Domain.Repositories
{
    public interface IDiscountRepository
    {
        Discount Get(string code);
    }
}