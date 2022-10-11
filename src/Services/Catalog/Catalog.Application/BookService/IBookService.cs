using Catalog.Domains.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.BookService
{
    public interface IBookService
    {
        IList<Book> Get();

        Book Get(int id);

        bool AddBookToTheBasket(int id, int userId);
    }
}
