using System.ComponentModel.DataAnnotations;

namespace UpetApi.DTOS
{
    public class LoginUserDTO
    {
        [Required]
        [StringLength(100)]
        public string correo { get; set; }

        [Required]
        [StringLength(18)]
        public string password { get; set; }
    }
}
