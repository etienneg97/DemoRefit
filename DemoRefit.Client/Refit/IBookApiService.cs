using DemoRefit.Client.Api;
using DemoRefit.Models;
using Refit;

namespace DemoRefit.Client.Refit
{
    public interface IBookApiService
    {
        [Get("/api/book/{id}")]
        Task<IApiResponse<Book>> GetBookByIdAsync(int id);

        [Get("/api/book")]
        Task<IApiResponse<List<Book>>> GetAllBooksAsync([Query] BookParameters parameters);

        [Post("/api/book")]
        Task<IApiResponse<Book>> CreateBookAsync([Body] Book newBook);

        [Put("/api/book/{id}")]
        Task<IApiResponse> UpdateBookAsync(int id, [Body] Book updatedBook);

        [Delete("/api/book/{id}")]
        Task<IApiResponse> DeleteBookAsync(int id);
    }
}
