using DemoRefit.Client.Api;
using DemoRefit.Models;
using Refit;

namespace DemoRefit.Client.Pages
{
    public partial class BookPage
    {
        private readonly IBookApi _bookApi;
        private Book book = new() { Id = 1 };
        private List<Book> books = new();
        private string message = "";

        public BookPage(IBookApi bookApi)
        {
            _bookApi = bookApi;
        }

        private async Task GetBook()
        {
            IApiResponse<Book> response = await _bookApi.GetBookByIdAsync(book.Id);
            if (response.IsSuccessStatusCode)
            {
                book = response.Content!;
                message = $"Livre trouvé: {book.Title}";
            }
            else
            {
                message = $"Livre non trouvé. Status: {response.StatusCode}";
            }
        }

        private async Task GetAllBooks()
        {
            IApiResponse<List<Book>> response = await _bookApi.GetAllBooksAsync();
            if (response.IsSuccessStatusCode)
            {
                books = response.Content!;
                message = $"Livres récupérés: {books.Count}";
            }
            else
            {
                message = $"Aucun livre trouvé. Status: {response.StatusCode}";
            }
        }

        private async Task PostBook()
        {
            IApiResponse<Book> response = await _bookApi.CreateBookAsync(book);
            if (response.IsSuccessStatusCode)
            {
                book = response.Content!;
                message = "Livre créé avec succès.";
            }
            else
            {
                message = $"Erreur lors de la création. Status: {response.StatusCode}";
            }
        }

        private async Task PutBook()
        {
            IApiResponse response = await _bookApi.UpdateBookAsync(book.Id, book);
            if (response.IsSuccessStatusCode)
            {
                message = "Livre mis à jour.";
            }
            else
            {
                message = $"Erreur PUT. Status: {response.StatusCode}";
            }
        }

        private async Task DeleteBook()
        {
            IApiResponse response = await _bookApi.DeleteBookAsync(book.Id);
            if (response.IsSuccessStatusCode)
            {
                message = "Livre supprimé.";
                book = new Book();
            }
            else
            {
                message = $"Erreur DELETE. Status: {response.StatusCode}";
            }
        }

    }
}
