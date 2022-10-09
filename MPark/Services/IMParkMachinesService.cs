using MPark.Shared;

namespace MPark.Services
{
    public interface IMParkMachinesService
    {
        //TODO don't get all, implement filter
        Task<IEnumerable<MParkMachine>?> GetAsync();
        Task<MParkMachine?> GetByIdAsync(Guid id);
        Task<MParkMachine?> PostAsync(CreateMParkMachine createMParkMachine);
        Task<MParkMachine?> DeleteAsync(Guid id);
        Task<MParkMachine?> PutAsync(UpdateMParkMachine updateMParkMachine);
    }
}