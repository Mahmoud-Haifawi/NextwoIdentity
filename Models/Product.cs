using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NextwoIdentity.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Please Enter Product Name")]
        [Display(Name = "Product Name")]
        public string? ProductName { get; set; }


        [Required(ErrorMessage = "Please Enter Price")]

        public decimal Price { get; set; }


        public string? Description { get; set; }



        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public Category? Category { get; set; }


    }
}
