using System.ComponentModel.DataAnnotations;

namespace UpetApi.Entidades
{
    public class OngUsers
    {
        public int id { get; set; }
        [Required]
        public string nombre { get; set; }

   
    public List<Sede> sedes { get; set; }
    }
}
