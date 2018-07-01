using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAPP.Models
{
    [Table("Animais")]
    public class Animal
    {
        [Key]
        public int Id { get; set; }

        [StringLength(30, MinimumLength=1)]
        [Required(ErrorMessage="O código da etiqueta é obrigatório.", AllowEmptyStrings=false)]
        public string Tag { get; set; }

        [Display(Name="Data da Compra")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]        
        public DateTime? DtCompra { get; set; } // se o valor for null = datatime.now

        [Display(Name="Data da Venda")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]        
        public DateTime? DtVenda { get; set; }
        
        //Propriedade comentada porq nem toda fazenda precisa ter um animal
        // [ForeignKey("Fazenda")]
        // public virtual Fazenda FazendaId { get; set; }1

        public virtual Fazenda Fazenda { get; set; }

        public virtual ICollection<Peso> Pesos { get; set; }
    }
}