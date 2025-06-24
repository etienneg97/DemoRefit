using DemoRefit.Client.Api;
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
            new Book { Id = 1, Title = "1984", Language = "en" },
            new Book { Id = 2, Title = "Le Meilleur des mondes", Language = "fr" },
            new Book { Id = 3, Title = "Fahrenheit 451", Language = "en" },
            new Book { Id = 4, Title = "L'Attrape-cœurs", Language = "fr" },
            new Book { Id = 5, Title = "To Kill a Mockingbird", Language = "en" },
            new Book { Id = 6, Title = "Gatsby le Magnifique", Language = "fr" },
            new Book { Id = 7, Title = "Moby Dick", Language = "en" },
            new Book { Id = 8, Title = "Guerre et Paix", Language = "fr" },
            new Book { Id = 9, Title = "Crime et Châtiment", Language = "fr" },
            new Book { Id = 10, Title = "Orgueil et Préjugés", Language = "fr" },
            new Book { Id = 11, Title = "The Lord of the Rings", Language = "en" },
            new Book { Id = 12, Title = "Harry Potter à l'école des sorciers", Language = "fr" },
            new Book { Id = 13, Title = "The Hobbit", Language = "en" },
            new Book { Id = 14, Title = "Les Aventures d'Alice au pays des merveilles", Language = "fr" },
            new Book { Id = 15, Title = "The Odyssey", Language = "en" },
            new Book { Id = 16, Title = "Jane Eyre", Language = "en" },
            new Book { Id = 17, Title = "Les Hauts de Hurlevent", Language = "fr" },
            new Book { Id = 18, Title = "La Divine Comédie", Language = "fr" },
            new Book { Id = 19, Title = "The Brothers Karamazov", Language = "en" },
            new Book { Id = 20, Title = "Don Quichotte", Language = "fr" }
        };

        // GET: api/book
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAllBooks(
            [FromQuery] BookParameters parameters,
            [FromHeader(Name = "X-Language")] string? language)
        {
            if (parameters == null)
            {
                parameters = new BookParameters();
            }

            IEnumerable<Book> query = _books;

            if (!string.IsNullOrWhiteSpace(language))
            {
                query = query.Where(b => b.Language.Equals(language, StringComparison.OrdinalIgnoreCase));
            }

            query = parameters.SortAsc ? query.OrderBy(b => b.Id) : query.OrderByDescending(b => b.Id);

            if (parameters.Ids != null && parameters.Ids.Any())
            {
                query = query.Where(b => parameters.Ids.Contains(b.Id));
            }

            if (parameters.Limit > 0)
            {
                query = query.Take(parameters.Limit);
            }

            return Ok(query.ToList());
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
