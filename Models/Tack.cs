using System.ComponentModel.DataAnnotations;

namespace TareaCRUD.Models
{
    public class Tack
    {
        public int id { get; set; }

        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public String title { get; set; } = null!;

        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public String Description { get; set; } = null!;

        public DateTime DateCreation { get; set; } 

    }
}

    