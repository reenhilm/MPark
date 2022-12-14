using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPark.Shared
{
    public class CreateMParkMachine
    {
        [Required]
        [StringLength(50)]
        public string City { get; set; } = String.Empty;
        [Required]
        public int CountryId { get; set; }
        [Required]
        public MachineType Type { get; set; }
        public string Data { get; set; } = default!;
        public DateTime LastUpdated { get; set; }
        public bool IsOnline { get; set; }
    }
}
