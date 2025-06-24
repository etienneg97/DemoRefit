using DemoRefit.Models;
using Refit;

namespace DemoRefit.Client.Api
{
    public interface IBookApi
    {
        [Get("/api/books/{id}")]
        Task<IApiResponse<Book>> GetBookByIdAsync(int id);

        [Get("/api/book")]
        Task<IApiResponse<List<Book>>> GetAllBooksAsync();

        [Post("/api/book")]
        Task<IApiResponse<Book>> CreateBookAsync([Body] Book newBook);

        [Put("/api/book/{id}")]
        Task<IApiResponse> UpdateBookAsync(int id, [Body] Book updatedBook);

        [Delete("/api/book/{id}")]
        Task<IApiResponse> DeleteBookAsync(int id);
    }

}
