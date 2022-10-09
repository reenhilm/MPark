using static MPark.Services.MParkMachinesService;
using System.Net.Http.Json;
using MPark.Shared;

namespace MPark.Services
{
    public class MParkMachinesService : IMParkMachinesService
    {
        private readonly HttpClient httpClient;

        public MParkMachinesService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public Task<MParkMachine?> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MParkMachine>?> GetAsync()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<MParkMachine>>("api/machines");
        }

        public async Task<MParkMachine?> GetByIdAsync(Guid id)
        {
            return await httpClient.GetFromJsonAsync<MParkMachine?>($"api/machines/{id}");
        }

        public async Task<MParkMachine?> PostAsync(CreateMParkMachine createMParkMachine)
        {
            var response = await httpClient.PostAsJsonAsync<CreateMParkMachine>("api/machines", createMParkMachine);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<MParkMachine>();

            return null;
        }

        public Task<MParkMachine?> PutAsync(UpdateMParkMachine updateMParkMachine)
        {
            throw new NotImplementedException();
        }
    }
}
