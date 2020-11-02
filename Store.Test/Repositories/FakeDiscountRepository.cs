using System;
using store.Domain.Entities;
using store.Domain.Repositories;

namespace store.test.Repositories
{
    public class FakeDiscountRepository : IDiscountRepository
    {
        public Discount Get(string code)
        {
            if (code == "12345678")
                return new Discount(10, DateTime.Now.AddDays(5));

            if (code == "1111111")
                return new Discount(10, DateTime.Now.AddDays(-5));
            
            return null;
        }
    }
}