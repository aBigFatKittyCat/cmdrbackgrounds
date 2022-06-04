using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Web;

namespace CommanderBackgrounds
{
    public class ScryFallClient
    {
        private readonly HttpClient _client;

        public ScryFallClient(HttpClient client)
        {
            _client = client;
        }

        public ScryFallClient()
        {
            _client = new HttpClient()
            {
                BaseAddress = new Uri("https://api.scryfall.com")
            };
        }

        public async Task<CardList> SearchCards(string searchQuery)
        {

            CardList result = await _client.GetFromJsonAsync<CardList>("cards/search?q=" + searchQuery) ?? new();

            return result;
        }


    }
}