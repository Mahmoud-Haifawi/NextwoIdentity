using System.ComponentModel.DataAnnotations;

namespace NextwoIdentity.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required]
        public string? CategoryName { get; set; }

    }
}
