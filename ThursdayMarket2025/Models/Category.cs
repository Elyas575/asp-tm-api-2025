using System.ComponentModel.DataAnnotations;

namespace ThursdayMarket2025.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        public string displayOrder { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }
    }
}
