using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPark.Shared
{
    public class UpdateMParkMachine
    {
        [Required]
        [StringLength(50)]
        public string City { get; set; } = String.Empty;
        [Required]
        public int CountryId { get; set; }
    }
}
