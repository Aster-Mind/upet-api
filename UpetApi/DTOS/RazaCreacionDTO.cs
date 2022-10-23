using System.ComponentModel.DataAnnotations;

namespace UpetApi.DTOS
{
    public class RazaCreacionDTO
    {

        [Required]
        [StringLength(40)]
        public string tipoAnimal { get; set; }

        [Required]
        [StringLength(40)]
        public string tipoRaza { get; set; }
    }
}
