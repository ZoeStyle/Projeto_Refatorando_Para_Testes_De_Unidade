using store.Domain.Entities;

namespace store.Domain.Repositories
{
    public interface ICustumerRepository
    {
        Custumer Get(string document);
    }
}