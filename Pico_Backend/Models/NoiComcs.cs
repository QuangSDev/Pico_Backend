using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pico_Backend.Models
{
    public class NoiComcs
    {
        public int ID { get; set; }
        public string? ProductName { get; set; }
        public string? ProductImage { get; set; }
        public string? ProductBrand { get; set; }
        public int? ProductQuantity { get; set; }
        public decimal? ProductPrice { get; set; }
        public string? ProductCapacity { get; set; }
        public string? ProductMaterial { get; set; }
      
    }
}
