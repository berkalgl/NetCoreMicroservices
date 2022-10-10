using Catalog.Application.BookService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet]
        public IActionResult Get() 
        {
            return Ok(_bookService.Get());
        }
        //[HttpGet("{id}")]
        //public IActionResult Get(int id)
        //{
        //    return Ok(_bookService.Get(id));
        //}

        [Route("[action]")]
        [HttpGet("{id}")]
        public IActionResult AddBookToTheBasket(int id, int userId)
        {
            return Ok(_bookService.AddBookToTheBasket(id,userId));
        }
    }
}
