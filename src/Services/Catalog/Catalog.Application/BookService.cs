using Catalog.DataAccess;
using Catalog.Domains;

namespace Catalog.Application
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IList<Book> Get()
        {
            return _bookRepository.GetAll();
        }
    }
}
