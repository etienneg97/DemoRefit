using DemoRefit.Client.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoRefit.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private static List<Book> _books = new()
        {
            new Book { Id = 1, Title = "1984" },
            new Book { Id = 2, Title = "Brave New World" }
        };

        // GET: api/book
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAllBooks()
        {
            return Ok(_books);
        }

        // GET: api/book/1
        [HttpGet("{id}")]
        public ActionResult<Book> GetBookById(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book == null)
                return NotFound();

            return Ok(book);
        }

        // POST: api/book
        [HttpPost]
        public ActionResult<Book> CreateBook([FromBody] Book newBook)
        {
            newBook.Id = _books.Any() ? _books.Max(b => b.Id) + 1 : 1;
            _books.Add(newBook);
            return CreatedAtAction(nameof(GetBookById), new { id = newBook.Id }, newBook);
        }

        // PUT: api/book/1
        [HttpPut("{id}")]
        public ActionResult UpdateBook(int id, [FromBody] Book updatedBook)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book == null)
                return NotFound();

            book.Title = updatedBook.Title;

            return NoContent();
        }

        // DELETE: api/book/1
        [HttpDelete("{id}")]
        public ActionResult DeleteBook(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book == null)
                return NotFound();

            _books.Remove(book);
            return NoContent();
        }
    }
}
