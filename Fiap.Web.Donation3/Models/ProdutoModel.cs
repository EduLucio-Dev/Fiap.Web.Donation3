using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Web.Donation3.Models
{
    [Table("Produto")]
    public class ProdutoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [HiddenInput]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage ="O campo nome é obrigatorio")]
        [StringLength(50, ErrorMessage ="O tamanho máximo do nome é 50 caracteres")]
        [Display(Name ="Nome do Produto")]
        public string Nome { get; set; }

        public bool Disponivel { get; set; }

        public string Descricao { get; set; }

        [Required]
        [StringLength(200)]
        public string SugestaoTroca { get; set; }

        [Required]
        [Range(10, 10000)]
        public double Valor { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;

        public DateTime DataExpiracao { get; set; } = DateTime.Today.AddDays(5);


        // Usuario dono do produto
        public int UsuarioId { get; set; }

        [ForeignKey(nameof(UsuarioId))]
        public UsuarioModel? Usuario { get; set; }

        //Categoria do Produto
        [Required]
        public int CategoriaId { get; set; }

        [ForeignKey(nameof(CategoriaId))]
        public CategoriaModel? Categoria { get; set; }

    }
}
