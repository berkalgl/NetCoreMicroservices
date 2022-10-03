using Catalog.Domains;

namespace Catalog.DataAccess
{
    public interface IRepository<T> where T : IEntity
    {
        IList<T> GetAll();

        T GetById(int id);
    }
}
