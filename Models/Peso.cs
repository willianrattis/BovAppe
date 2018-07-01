using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace SAPP.Models
{
    [Table("Pesos")]
    public class Peso
    {
        [Key]
        public int Id { get; set; }
        
        //[StringLength(4, MinimumLength=1, ErrorMessage="Insira no máximo 4 caracteres e no mínimo 1 caracteres.")]        
        [Required(ErrorMessage="O peso do animal é obrigatório.", AllowEmptyStrings=false)]        
        public float Quilos { get; set; } = 180;

        [Display(Name="Data da Pesagem")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? Dtpesagem { get; set; }

        [ForeignKey("Animal")]
        [Display(Name="Animal")]
        public int AnimalId { get; set; }
        public virtual Animal Animal { get; set; }
    }
}