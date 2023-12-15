using Microsoft.AspNetCore.Mvc;

namespace Pico_Backend.Models
{
    public class Televison 
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public int? ProductBrand { get; set; }
        public int? ProductPrice { get; set; }
        public int? ProductSize { get; set; }
        public int? ProductOrigin { get; set; }
        public string? ProductMaterial { get; set; }
        public string? ProductYear { get; set; }
        public decimal? ProductWeight { get; set; }
        public int? ProductQuantity { get; set; }
        public string? ProductImage { get; set; }
    }
}
