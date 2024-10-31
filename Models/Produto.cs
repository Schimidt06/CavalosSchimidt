using System.ComponentModel.DataAnnotations;

namespace CavalosSchimidt.Models
{
    public class Vendaitem
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Descrição é obrigatória")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Preço é obrigatório")]
        [Range(0, double.MaxValue)]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "Quantidade é obrigatória")]
        [Range(0, int.MaxValue)]
        public int QuantidadeEstoque { get; set; }

        [Required(ErrorMessage = "Fornecedor é obrigatório")]
        public int FornecedorId { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }

    }

}

