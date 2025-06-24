using DemoRefit.Models;
using Refit;

namespace DemoRefit.Client.Api
{
    public interface IBookApi
    {
        [Get("/api/book")]
        Task<List<Book>> GetAllBooksAsync();

        [Get("/api/book/{id}")]
        Task<Book> GetBookByIdAsync(int id);

        [Post("/api/book")]
        Task<Book> CreateBookAsync([Body] Book newBook);

        [Put("/api/book/{id}")]
        Task UpdateBookAsync(int id, [Body] Book updatedBook);

        [Delete("/api/book/{id}")]
        Task DeleteBookAsync(int id);
    }
}
