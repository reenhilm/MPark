using System.Diagnostics.Metrics;

namespace MPark.Shared
{
    public class MParkMachine
    {
        public Guid Id { get; set; } = new Guid();
        public int CountryId { get; set; }
        public Country Country { get; set; } = default!;
        public string City { get; set; }
        public MachineType Type { get; set; }
        public string Data { get; set; } = default!;
        public DateTime LastUpdated { get; set; }
        public bool IsOnline { get; set; }
    }
}