using DemoRefit.Models;
using System.Net.Http.Json;

namespace DemoRefit.Client.Pages
{
    public partial class BookPage
    {
        private HttpClient _httpClient;
        private Book book = new() { Id = 1 };
        private List<Book> books = new();
        private string message = "";

        public BookPage(HttpClient Http)
        {
            _httpClient = Http;
        }

        private async Task GetBook()
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<Book>($"api/book/{book.Id}");
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
                var result = await _httpClient.GetFromJsonAsync<List<Book>>("api/book");
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
                var response = await _httpClient.PostAsJsonAsync("api/book", book);
                if (response.IsSuccessStatusCode)
                {
                    message = "Livre créé avec succès.";
                }
                else
                {
                    message = $"Erreur POST: {response.ReasonPhrase}";
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
                var response = await _httpClient.PutAsJsonAsync($"api/book/{book.Id}", book);
                if (response.IsSuccessStatusCode)
                {
                    message = "Livre mis à jour.";
                }
                else
                {
                    message = $"Erreur PUT: {response.ReasonPhrase}";
                }
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
                var response = await _httpClient.DeleteAsync($"api/book/{book.Id}");
                if (response.IsSuccessStatusCode)
                {
                    message = "Livre supprimé.";
                    book = new Book(); // reset
                }
                else
                {
                    message = $"Erreur DELETE: {response.ReasonPhrase}";
                }
            }
            catch (Exception ex)
            {
                message = $"Erreur DELETE: {ex.Message}";
            }
        }
    }
}
