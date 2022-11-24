using System.ComponentModel.DataAnnotations;

namespace UpetApi.Entidades
{
    public class organizacion
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string nombre { get; set; }
        [Required]
        [StringLength(50)]
        public string correo { get; set; }
        public string imagen { get; set; }
        public string telefono { get; set; }

        [Required]
        [StringLength(50)]
        public string pais { get; set; }

        [Required]
        [StringLength(50)]
        public string estado { get; set; }

        [Required]
        [StringLength(50)]
        public string municipio { get; set; }

        [Required]
        public int codigoPostal { get; set; }

        [Required]
        [StringLength(50)]
        public string colonia { get; set; }

        [Required]
        [StringLength(100)]
        public string calle { get; set; }

        [Required]
        public int numeroExterior { get; set; }

        public int numeroInterior { get; set; }
        public string link { get; set; }
        [Required]
        [StringLength(100)]
        public string usuario { get; set; }
        [Required]
        [StringLength(100)]
        public string password { get; set; }

        public string historia { get; set; }

        public bool verificado { get; set; } = false;
    }
}
