using Refit;

namespace DemoRefit.Client.Refit
{
    public interface IDateApiService
    {
        [Get("/api/date")]
        Task<IApiResponse<DateTime>> GetServeurDateTime();
    }
}
