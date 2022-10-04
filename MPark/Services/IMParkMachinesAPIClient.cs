using MPark.Shared;

namespace MPark.Services
{
    public interface IMParkMachinesAPIClient
    {
        Task<IEnumerable<MParkMachine>?> GetAsync();
        Task<MParkMachine?> PostAsync(CreateMParkMachine createMParkMachine);
    }
}