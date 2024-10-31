using System.ComponentModel.DataAnnotations;

namespace CavalosSchimidt.Models
{
    public class VendaItem
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid VendaId { get; set; }

        [Required]
        public Guid ProdutoId { get; set; }

        [Required(ErrorMessage = "Quantidade é obrigatória")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantidade deve ser maior que zero")]
        [Display(Name = "Quantidade")]
        public int Quantidade { get; set; }

        [Required]
        [Display(Name = "Preço Unitário")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Currency)]
        public decimal PrecoUnitario { get; set; }

        [Display(Name = "Valor Total")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        public decimal ValorTotal { get { return Quantidade * PrecoUnitario; } }

        public  Venda Venda { get; set; }
        public  Produto Produto { get; set; }
    }

}

