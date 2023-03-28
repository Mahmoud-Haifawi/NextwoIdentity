using System.ComponentModel.DataAnnotations;

namespace NextwoIdentity.Models.ViewModel
{
    public class CreateRoleViewModel
    {
        [Required]
        public string? RoleName { get; set; }

    }
}
