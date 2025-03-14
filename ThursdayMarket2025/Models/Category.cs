using System.ComponentModel.DataAnnotations;

namespace ThursdayMarket2025.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(45)]
        [RegularExpression(@"^[a-zA-Z]+[0-9]*$", ErrorMessage = "Name must start with letters")]
        public string Name { get; set; }

        [Range(1,1000, ErrorMessage ="Display Order must be between 1 and 1000")]
        public int DisplayOrder { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }
    }
}
