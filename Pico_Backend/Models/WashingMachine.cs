using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pico_Backend.Models
{
    public class WashingMachine
    {
        public int ID { get; set; }
        public string? ProductName { get; set; }
        public decimal? ProductWeight { get; set; }
        public int? RotationSqeed { get; set; }
        public string? ProductMaterial { get; set; }
        public string? ProductOrigin { get; set; }
        public string? ManufactureYear { get; set; }
        public string? ProductImage { get; set; }
    }
}
