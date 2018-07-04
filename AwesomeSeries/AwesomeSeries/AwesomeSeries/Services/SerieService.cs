using System.Threading.Tasks;
using AwesomeSeries.Infra;
using AwesomeSeries.Infra.Api;
using AwesomeSeries.Models;

namespace AwesomeSeries.Services
{
    public class SerieService : ISerieService
    {
        readonly ITmdbApi _api;

        public SerieService(ITmdbApi api)
        {
            _api = api;
        }

        public async Task<SerieResponse> GetSeriesAsync()
        {
            return await _api.GetSerieResponseAsync(AppSettings.ApiKey);
        }
    }
}
