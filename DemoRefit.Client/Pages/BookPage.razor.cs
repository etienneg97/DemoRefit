using DemoRefit.Client.Api;
using DemoRefit.Models;

namespace DemoRefit.Client.Pages
{
    public partial class BookPage
    {
        private readonly IBookApi _bookApi;
        private Book book = new() { Id = 1 };
        private List<Book> books = new();
        private string message = "";

        // Injection via constructeur
        public BookPage(IBookApi bookApi)
        {
            _bookApi = bookApi;
        }

        private async Task GetBook()
        {
            try
            {
                var result = await _bookApi.GetBookByIdAsync(book.Id);
                if (result != null)
                {
                    book = result;
                    message = $"Livre trouvé: {book.Title}";
                }
                else
                {
                    message = "Livre non trouvé.";
                }
            }
            catch (Exception ex)
            {
                message = $"Erreur GET: {ex.Message}";
            }
        }

        private async Task GetAllBooks()
        {
            try
            {
                var result = await _bookApi.GetAllBooksAsync();
                if (result != null)
                {
                    books = result;
                    message = $"Livres récupérés: {books.Count}";
                }
                else
                {
                    message = "Aucun livre trouvé.";
                }
            }
            catch (Exception ex)
            {
                message = $"Erreur GET ALL: {ex.Message}";
            }
        }

        private async Task PostBook()
        {
            try
            {
                var createdBook = await _bookApi.CreateBookAsync(book);
                if (createdBook != null)
                {
                    message = "Livre créé avec succès.";
                    book = createdBook;
                }
                else
                {
                    message = "Erreur lors de la création.";
                }
            }
            catch (Exception ex)
            {
                message = $"Erreur POST: {ex.Message}";
            }
        }

        private async Task PutBook()
        {
            try
            {
                await _bookApi.UpdateBookAsync(book.Id, book);
                message = "Livre mis à jour.";
            }
            catch (Exception ex)
            {
                message = $"Erreur PUT: {ex.Message}";
            }
        }

        private async Task DeleteBook()
        {
            try
            {
                await _bookApi.DeleteBookAsync(book.Id);
                message = "Livre supprimé.";
                book = new Book();
            }
            catch (Exception ex)
            {
                message = $"Erreur DELETE: {ex.Message}";
            }
        }
    }
}
