using System.ComponentModel.DataAnnotations;

namespace UpetApi.DTOS
{
    public class OngCreacionDTO
    {
        [Required]
        [StringLength(50)]
        public string nombre { get; set; }
    }
}
