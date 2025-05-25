using System.ComponentModel.DataAnnotations;

namespace Shopping_API_Jueves_práctica.DAL.Entities
{
    public class State : AuditBase
    {
        [Display(Name = "Estado/Departamento")] // Para identificar el nombre más fácil
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Name { get; set; }

        //Así relaciono 2 tablas con EF Core

        [Display(Name = "Pais")]
        public Country? Country { get; set; }

        //FK
        [Display(Name = "id pais")]
        public Guid CountryId { get; set; }

    }
}
