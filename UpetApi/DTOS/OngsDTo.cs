using System.ComponentModel.DataAnnotations;
using UpetApi.Entidades;

namespace UpetApi.DTOS
{
    public class OngsDTo
    {

        public int id { get; set; }
        [Required]
        public string nombre { get; set; }


        public List<Sede> sedes { get; set; }
    }
}
