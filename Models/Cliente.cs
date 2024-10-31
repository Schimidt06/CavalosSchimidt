using CavalosSchimidt.Models;
using System.ComponentModel.DataAnnotations;


public class Cliente
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required(ErrorMessage = "O nome é obrigatório")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 100 caracteres")]
    [Display(Name = "Nome do Cliente")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "CPF/CNPJ é obrigatório")]
    [StringLength(18, MinimumLength = 11, ErrorMessage = "CPF/CNPJ inválido")]
    [Display(Name = "CPF/CNPJ")]
    [RegularExpression(@"([0-9]{11}|[0-9]{14})", ErrorMessage = "CPF/CNPJ inválido")]
    public string CpfCnpj { get; set; }

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

    [Display(Name = "Cliente Ativo?")]
    public bool Ativo { get; set; } = true;

    [Display(Name = "Data de Cadastro")]
    [DataType(DataType.DateTime)]
    public DateTime DataCadastro { get; set; } = DateTime.Now;

    public virtual ICollection<Venda> Vendas { get; set; }
}


