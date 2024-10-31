using System.ComponentModel.DataAnnotations;

namespace CavalosSchimidt.Models
{
    public class Venda
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Cliente é obrigatório")]
        [Display(Name = "Cliente")]
        public Guid ClienteId { get; set; }

        [Display(Name = "Data da Venda")]
        [DataType(DataType.DateTime)]
        public DateTime DataVenda { get; set; } = DateTime.Now;

        [Display(Name = "Valor Total")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Currency)]
        public decimal ValorTotal { get; set; }

        [Display(Name = "Observações")]
        [StringLength(500)]
        [DataType(DataType.MultilineText)]
        public string Observacoes { get; set; }

        public  Cliente Cliente { get; set; }
        public  ICollection<VendaItem> Itens { get; set; }
    }



}

