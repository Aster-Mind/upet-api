using System.ComponentModel.DataAnnotations;

namespace UpetApi.DTOS
{
    public class MascotasCreacionDTO
    {
        [Required]
        [StringLength(40)]
        public string tipo { get; set; }
        [Required]
        [StringLength(40)]
        public string raza { get; set; }
        [Required]
        public string imagen { get; set; }

        [Required]
        public bool adoptado { get; set; }
    }
}
