using store.Domain.Entities;
using store.Domain.Repositories;
//Mocks
namespace store.test.Repositories
{
    public class FakeCustumerRepository : ICustumerRepository
    {
        public Custumer Get(string document)
        {
            if(document == "12345678911")
                return new Custumer("Victor Hernandes", "regiotimao@gmail.com");

            return null;
        }
        
    }
}