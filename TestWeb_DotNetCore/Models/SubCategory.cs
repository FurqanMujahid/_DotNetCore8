using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Newtonsoft.Json.Serialization;

namespace TestWeb_DotNetCore.Models
{
    public class SubCategory
    {
        public int SubCategoryId { get; set; }
        [Required]
        [DisplayName("Sub Category Name")]
        public string? SubCategoryName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        // Foreign key property
        public int CategoryId { get; set; }

        // Navigation property
        public Category? Category { get; set; }

    }
}
