using System.ComponentModel.DataAnnotations;

namespace Shopping_API_Jueves_práctica.DAL.Entities
{
    public class Country : AuditBase
    {
        [Display(Name = "País")] // Para identificar el nombre más fácil
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        [Required(ErrorMessage ="El campo {0} es obligatorio")]
        public string Name { get; set; }
    }
}
