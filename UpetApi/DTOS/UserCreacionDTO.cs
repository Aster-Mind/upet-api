using System.ComponentModel.DataAnnotations;

namespace UpetApi.DTOS
{
    public class UserCreacionDTO
    {

        [Required]
        [StringLength(100)]
        public string correo { get; set; }

        [Required]
        [StringLength(12)]
        public string telefono { get; set; }

        [Required]
        [StringLength(50)]
        public string nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string apellido { get; set; }

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

        [Required]
        public string ine { get; set; }

        [Required]
        [StringLength(18)]
        public string password { get; set; }
    }
}
