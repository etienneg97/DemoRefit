namespace DemoRefit.Client.Handlers
{
    public class LanguageHandler : DelegatingHandler
    {
        private readonly string _language;

        public LanguageHandler(string language = "fr")
        {
            _language = language;
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            request.Headers.Remove("X-Language");
            request.Headers.Add("X-Language", _language);

            return await base.SendAsync(request, cancellationToken);
        }

    }
}
