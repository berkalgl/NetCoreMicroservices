using Catalog.DataAccess.Data;
using Catalog.DataAccess.Repositories.Interfaces;
using Catalog.Domains.Entities;

namespace Catalog.DataAccess.Repositories.Implementation
{
    public class BookRepository : IBookRepository
    {
        private readonly CatalogDbContext _catalogDbContext;

        public BookRepository(CatalogDbContext catalogDbContext)
        {
            _catalogDbContext = catalogDbContext;
        }

        public IList<Book> GetAll()
        {
            return _catalogDbContext.Books.ToList();
        }

        public Book GetById(int id)
        {
            return _catalogDbContext.Books.FirstOrDefault(x => x.Id == id) ?? new Book();
        }
    }
}
