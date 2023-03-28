using System.ComponentModel.DataAnnotations;

namespace NextwoIdentity.Models.ViewModel
{
    public class RegisterViewModel
    {
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Enter Email")]
        public string? Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Enter Password")]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Enter Confirm Password")]
        [Compare("Password",ErrorMessage = "Confirm and Password not match")]
        public string? ConfirmPassword { get; set; }


        [Required(ErrorMessage = "Enter Phone Number")]
        public string? Phone { get; set; }
    }
}
