using System.ComponentModel.DataAnnotations;

namespace TareaCRUD.Models
{
    public class User
    {
        public int id { get; set; }
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public String Name { get; set; } = null!;
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public String Email { get; set; } = null!;

        public DateTime DateCreation { get; set; }


    }
}
