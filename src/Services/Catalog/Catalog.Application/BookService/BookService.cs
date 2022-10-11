using Catalog.DataAccess.Repositories.Interfaces;
using Catalog.Domains.Entities;
using MassTransit;
using MessagesAndEvents.Requests;

namespace Catalog.Application.BookService
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IPublishEndpoint _publishEndpoint;

        public BookService(IBookRepository bookRepository, IPublishEndpoint publishEndpoint)
        {
            _bookRepository = bookRepository;
            _publishEndpoint = publishEndpoint;
        }

        public bool AddBookToTheBasket(int id, int userId)
        {
            var addedBook = Get(id);

            // async calling
            //Rabbit MQ
            AddBookToBasketRequest request = new AddBookToBasketRequest
            {
                BookId = addedBook.Id,
                Description = addedBook.Description,
                Name = addedBook.Name,
                Price = addedBook.Price,
                UserId = userId
            };

            _publishEndpoint.Publish(request);
            return true;
        }

        public IList<Book> Get()
        {
            return _bookRepository.GetAll();
        }

        public Book Get(int id)
        {
            return _bookRepository.GetById(id);
        }
    }
}
