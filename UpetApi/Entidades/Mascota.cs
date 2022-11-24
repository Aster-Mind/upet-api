using System.ComponentModel.DataAnnotations;

namespace UpetApi.Entidades
{
    public class Mascota
    {

        public int id { get; set; }

        [Required]
        [StringLength(40)]
        public string nombre { get; set; }
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

        public string  ubicacion { get; set; }
        public string  historia { get; set; }
        public int  edad { get; set; }
        public string color { get; set; }
        public string duenoFoto { get; set; }
        public string duenoNombre { get; set; }
        public string duenoHistoria { get; set; }
        public string peso { get; set; }
        public string genero { get; set; }
    }
}
