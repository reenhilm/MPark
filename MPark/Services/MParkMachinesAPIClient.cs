using static MPark.Services.MParkMachinesAPIClient;
using System.Net.Http.Json;
using MPark.Shared;

namespace MPark.Services
{
    public class MParkMachinesAPIClient : IMParkMachinesAPIClient
    {
        private readonly HttpClient httpClient;

        public MParkMachinesAPIClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<MParkMachine>?> GetAsync()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<MParkMachine>>("api/machines");
        }

        public async Task<MParkMachine?> PostAsync(CreateMParkMachine createMParkMachine)
        {
            var response = await httpClient.PostAsJsonAsync<CreateMParkMachine>("api/machines", createMParkMachine);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<MParkMachine>();

            return null;
        }
    }
}
