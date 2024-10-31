using System.ComponentModel.DataAnnotations;

namespace CavalosSchimidt.Models
{
    public class Fornecedor
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "O nome da empresa é obrigatório")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 100 caracteres")]
        [Display(Name = "Nome da Empresa")]
        public string NomeEmpresa { get; set; }

        [Required(ErrorMessage = "CNPJ é obrigatório")]
        [StringLength(18, MinimumLength = 14, ErrorMessage = "CNPJ inválido")]
        [Display(Name = "CNPJ")]
        [RegularExpression(@"[0-9]{14}", ErrorMessage = "CNPJ deve conter 14 dígitos numéricos")]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "Endereço é obrigatório")]
        [StringLength(200, ErrorMessage = "Endereço não pode exceder 200 caracteres")]
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Telefone é obrigatório")]
        [Phone(ErrorMessage = "Telefone inválido")]
        [Display(Name = "Telefone")]
        [RegularExpression(@"^\([1-9]{2}\) (?:[2-8]|9[1-9])[0-9]{3}\-[0-9]{4}$",
            ErrorMessage = "Formato válido: (99) 99999-9999")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        [Display(Name = "E-mail")]
        [StringLength(100)]
        public string Email { get; set; }

        [Display(Name = "Data de Cadastro")]
        [DataType(DataType.DateTime)]
        public DateTime DataCadastro { get; set; } = DateTime.Now;

        public virtual ICollection<Produto> Produtos { get; set; }
    }

    // Models/Produto.cs
    public class Produto
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 100 caracteres")]
        [Display(Name = "Nome do Produto")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Descrição é obrigatória")]
        [StringLength(500, ErrorMessage = "Descrição não pode exceder 500 caracteres")]
        [Display(Name = "Descrição")]
        [DataType(DataType.MultilineText)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Preço é obrigatório")]
        [Range(0, double.MaxValue, ErrorMessage = "Preço deve ser maior que zero")]
        [Display(Name = "Preço")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Currency)]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "Quantidade é obrigatória")]
        [Range(0, int.MaxValue, ErrorMessage = "Quantidade deve ser maior ou igual a zero")]
        [Display(Name = "Quantidade em Estoque")]
        public int QuantidadeEstoque { get; set; }

        [Required(ErrorMessage = "Fornecedor é obrigatório")]
        [Display(Name = "Fornecedor")]
        public Guid FornecedorId { get; set; }

        [Display(Name = "Data de Cadastro")]
        [DataType(DataType.DateTime)]
        public DateTime DataCadastro { get; set; } = DateTime.Now;

        public virtual Fornecedor Fornecedor { get; set; }
        public virtual ICollection<VendaItem> VendaItens { get; set; }
    }

}
