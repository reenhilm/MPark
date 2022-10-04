namespace MPark.Shared
{
    public class MParkMachine
    {
        public Guid Id { get; set; } = new Guid();
        public string LocationCity { get; set; }
        public string LocationCountry { get; set; }
        public MachineType Type { get; set; }
        public string Data { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool IsOnline { get; set; }
    }
}