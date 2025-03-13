using System.ComponentModel.DataAnnotations;

namespace ThursdayMarket2025.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; } 
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }
    }
}
