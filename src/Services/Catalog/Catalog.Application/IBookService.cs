using Catalog.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application
{
    public interface IBookService
    {
        IList<Book> Get();

        Book Get(int id);
    }
}
