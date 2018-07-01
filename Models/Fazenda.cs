using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAPP.Models
{
    [Table("Fazendas")]
    public class Fazenda
    {
        [Key]
        public int Id { get; set; }

        [Display(Name="Fazenda")]
        [StringLength(30, MinimumLength=2)]
        [Required(ErrorMessage="O nome da fazenda é orbigatório.", AllowEmptyStrings=false)]
        public string Nome { get; set; }

        [ForeignKey("Cliente")]
        [Display(Name="Cliente")]
        public int ClienteId { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual ICollection<Animal> Animais { get; set; }
    }
}