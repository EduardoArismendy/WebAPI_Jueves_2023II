using System.ComponentModel.DataAnnotations;

namespace Shopping_API_Jueves_práctica.DAL.Entities
{
    public class AuditBase
    {
        [Key] //PK
        [Required] //Significa que este campo es obligatorio
        public virtual Guid Id { get; set; } // Esta será el PK de todas las tablas

        public virtual DateTime? CreatedDate { get; set; } // Guardar todo registro nuevo con su fecha

        public virtual DateTime? ModifiedDate { get; set; } //Guardar todo registro que se modificó
    }
}
