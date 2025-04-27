using System.ComponentModel.DataAnnotations;

namespace Solution.Domain
{
    public class Curso
    {
        [Key]
        public Guid CursoId { get; set; }
        [Required]
        [StringLength(100)]
        public string Titulo {  get; set; }
        [Required]
        [StringLength(200)]
        public string Descripcion { get; set; }
        [DataType(DataType.Date)]
        [DateInFutureAttribute]
        public DateTime? FechaPublicacion { get; set; }
        [DataType(DataType.Date)]
        public DateTime? FechaCreacion { get; set; }
        public decimal Precio { get; set; }
    }
}
