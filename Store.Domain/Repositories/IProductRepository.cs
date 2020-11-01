using System;
using System.Collections.Generic;
using store.Domain.Entities;

namespace store.Domain.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> Get(IEnumerable<Guid> ids);
    }
}