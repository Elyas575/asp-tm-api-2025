using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThursdayMarket.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public double? Price3Kg { get; set; }
        public double Weight { get; set; }
        public string Image { get; set; }
    }
}
