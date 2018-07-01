using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAPP.Models
{
 [Table("Clientes")]
    public class Cliente //Um cliente vai ter um cadastro, então devo relacionar cliente a login 1:1
    {
        [Key]
        public int Id { get; set; }

        [Display(Name="Nome")]
        [StringLength(30, MinimumLength=2)]
        [Required(ErrorMessage="O nome do cliente é obrigatório.", AllowEmptyStrings=false)]
        public string Nome { get; set; }

        [Display(Name="CPF")]
        [StringLength(14, MinimumLength=14)] //371 165 428 25
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:###.###.###-##}")]
        [Required(ErrorMessage="O CPF do cliente é obrigatório.", AllowEmptyStrings=false)]
        public string CPF { get; set; }

        [Display(Name="Senha")]
        [DataType(DataType.Password)]
        [StringLength(8, MinimumLength=4, ErrorMessage="Insira no máximo 8 caracteres e no mínimo 4 caracteres.")]
        [Required(ErrorMessage="A senha do cliente é obrigatória.", AllowEmptyStrings=false)]
        public string Senha { get; set; }

        public virtual ICollection<Fazenda> Fazendas { get; set; }
    }
}