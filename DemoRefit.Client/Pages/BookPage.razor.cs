using DemoRefit.Client.Api;
using DemoRefit.Client.Refit;
using DemoRefit.Models;

namespace DemoRefit.Client.Pages
{
    public partial class BookPage
    {
        private readonly IBookApiService _bookApiService;
        private readonly IDateApiService _dateApiService;

        private Book book = new() { Id = 1 };
        private List<Book> books = new();
        private string message = "";
        private string _idsInput = "";
        private DateTime _lastApiCall = DateTime.Now;

        private BookParameters _parameters = new BookParameters
        {
            SortAsc = true,
            Limit = 10
        };

        public BookPage(IBookApiService bookApiService,
                        IDateApiService dateApiService)
        {
            _bookApiService = bookApiService;
            _dateApiService = dateApiService;
        }

        private async Task GetBook()
        {
            var response = await _bookApiService.GetBookByIdAsync(book.Id);
            if (response.IsSuccessStatusCode)
            {
                book = response.Content!;
                books.Clear();
                books.Add(book);
                message = $"Livre trouvé: {book.Title}";
                await UpdateLastApiCall();
            }
            else
            {
                message = $"Livre non trouvé. Status: {response.StatusCode}";
            }
        }

        private async Task GetAllBooks()
        {
            _parameters.Ids = GetIds();
            var response = await _bookApiService.GetAllBooksAsync(_parameters);
            if (response.IsSuccessStatusCode)
            {
                books = response.Content!;
                message = $"Livres récupérés: {books.Count}";
                await UpdateLastApiCall();
            }
            else
            {
                message = $"Aucun livre trouvé. Status: {response.StatusCode}";
            }
        }

        private async Task PostBook()
        {
            var response = await _bookApiService.CreateBookAsync(book);
            if (response.IsSuccessStatusCode)
            {
                book = response.Content!;
                message = "Livre créé avec succès.";
                await UpdateLastApiCall();
            }
            else
            {
                message = $"Erreur lors de la création. Status: {response.StatusCode}";
            }
        }

        private async Task PutBook()
        {
            var response = await _bookApiService.UpdateBookAsync(book.Id, book);
            if (response.IsSuccessStatusCode)
            {
                message = "Livre mis à jour.";
                await UpdateLastApiCall();
            }
            else
            {
                message = $"Erreur PUT. Status: {response.StatusCode}";
            }
        }

        private async Task DeleteBook()
        {
            var response = await _bookApiService.DeleteBookAsync(book.Id);
            if (response.IsSuccessStatusCode)
            {
                message = "Livre supprimé.";
                book = new Book();
                await UpdateLastApiCall();
            }
            else
            {
                message = $"Erreur DELETE. Status: {response.StatusCode}";
            }
        }

        private async Task UpdateLastApiCall()
        {
            var response = await _dateApiService.GetServeurDateTime();
            if (response.IsSuccessStatusCode)
            {
                _lastApiCall = response.Content!;
            }
            else
            {
                message = $"Erreur lors de la récupération de la date. Status: {response.StatusCode}";
            }

        }

        private int[] GetIds()
        {
            int[] ids = [];
            if (!string.IsNullOrWhiteSpace(_idsInput))
            {
                ids = _idsInput
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(idStr =>
                    {
                        bool ok = int.TryParse(idStr.Trim(), out int id);
                        return ok ? id : (int?)null;
                    })
                    .Where(id => id.HasValue)
                    .Select(id => id.Value)
                    .ToArray();
            }

            return ids;
        }

    }
}
