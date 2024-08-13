using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace TestWeb_DotNetCore.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        [DisplayName("Category Name")]
        public string? Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "Display order must be in between 1 and 100 only")]
        public int DisplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        public ICollection<SubCategory>? SubCategories { get; set; }
    }
}
