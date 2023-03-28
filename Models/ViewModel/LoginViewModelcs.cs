using System.ComponentModel.DataAnnotations;

namespace NextwoIdentity.Models.ViewModel
{
    public class LoginViewModelcs
    {

        [EmailAddress]
        [Required(ErrorMessage = "Enter Email")]
        public string? Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Enter Password")]
        public string? Password { get; set; }

    }
}
