using Microsoft.AspNetCore.Mvc;
using MongoBookStore.Core.Services;


namespace MongoBookstore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult GetBooks(int id)
        {
            return Ok(_bookService.GetBooks());
        }
    }
}