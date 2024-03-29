﻿using Catalog.DataAccess.Repositories.Interfaces;
using Catalog.Domains.Entities;

namespace Catalog.DataAccess.Repositories.Implementation
{
    public class FakeBookRepository : IBookRepository
    {
        public IList<Book> GetAll()
        {
            return new List<Book>()
            {
                new Book(){Id = 1, Description = "Book 1"},
                new Book(){Id = 2, Description = "Book 2"},
                new Book(){Id = 3, Description = "Book 3"},
                new Book(){Id = 4, Description = "Book 4"}
            };
        }

        public Book GetById(int id)
        {
            return new Book() { Id = 1, Description = "Book 1" };
        }
    }
}
