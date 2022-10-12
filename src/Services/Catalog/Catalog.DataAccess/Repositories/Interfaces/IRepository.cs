using Catalog.Domains.Base;

namespace Catalog.DataAccess.Repositories.Interfaces
{
    public interface IRepository<T> where T : IEntity
    {
        IList<T> GetAll();

        T GetById(int id);
    }
}
