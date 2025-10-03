using Infrastructure.ExternalServices.PokeApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ExternalServices.PokeApi
{

    public class BerryService
    {
        HttpClient pokeClient;
        public BerryService(IHttpClientFactory httpClientFactory) 
        {
            pokeClient = httpClientFactory.CreateClient("pokeApiHttpClient");
            pokeClient.BaseAddress = new Uri(pokeClient.BaseAddress!, "berry/");
        }

        public async Task<GetPokeByIdResponse> GetBerries(int id)
        {

            var response = await pokeClient.GetFromJsonAsync<GetPokeByIdResponse>($"{id }");
            return response;
        }


    }

    
}
