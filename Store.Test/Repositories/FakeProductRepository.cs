using System;
using System.Collections.Generic;
using store.Domain.Entities;
using store.Domain.Repositories;

namespace store.test.Repositories
{
    public class FakeProductRepository : IProductRepository
    {
        public IEnumerable<Product> Get(IEnumerable<Guid> ids)
        {
            IList<Product> products = new List<Product>();
            products.Add(new Product("Porduto 01", 10, true));
            products.Add(new Product("Porduto 02", 10, true));
            products.Add(new Product("Porduto 03", 10, true));
            products.Add(new Product("Porduto 04", 10, false));
            products.Add(new Product("Porduto 05", 10, false));

            return products;
        }
    }
}