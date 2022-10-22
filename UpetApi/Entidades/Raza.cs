using System.ComponentModel.DataAnnotations;

namespace UpetApi.Entidades
{
    public class Raza
    {

        public int id { get; set; }

        [Required]
        [StringLength(40)]
        public string tipoAnimal { get; set; }

        [Required]
        [StringLength(40)]
        public string tipoRaza { get; set; }
    }
}
