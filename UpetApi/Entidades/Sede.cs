using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations;

namespace UpetApi.Entidades
{
    public class Sede
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string nombre { get; set; }
        [Required]
        [StringLength(50)]
        public string correo { get; set; }

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
        public int ongId { get; set; }


        public OngUsers ongusers { get; set; }
    }
}
