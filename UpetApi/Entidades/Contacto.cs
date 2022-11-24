using System.ComponentModel.DataAnnotations;

namespace UpetApi.Entidades
{
    public class Contacto
    {
      
        public int id { get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        public string correo { get; set; }
        [Required]
        public string mensaje { get; set; }

    }
}
