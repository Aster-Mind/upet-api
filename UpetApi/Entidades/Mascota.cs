using System.ComponentModel.DataAnnotations;

namespace UpetApi.Entidades
{
    public class Mascota
    {

        public int id { get; set; }

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
