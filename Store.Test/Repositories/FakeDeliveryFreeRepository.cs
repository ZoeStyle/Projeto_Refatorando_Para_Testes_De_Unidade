using store.Domain.Repositories;

namespace store.test.Repositories
{
    public class FakeDeliveryFreeRepository : IDeliveryFreeRepository
    {
        public decimal Get(string zipCode)
        {
            return 10;
        }
    }
}