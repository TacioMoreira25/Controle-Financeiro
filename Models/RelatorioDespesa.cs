using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceControl.Models
{
    public class RelatorioDespesa
    {
        [Key]
        public int ItemId { get; set; }

        [Required(ErrorMessage = "O nome da despesa é obrigatório.")]
        [StringLength(200, ErrorMessage = "O nome da despesa não pode ter mais de 200 caracteres.")]
        [Display(Name = "Despesa")]
        public string ItemNome { get; set; } = string.Empty; // Valor padrão definido como string vazia

        [Required(ErrorMessage = "O valor da despesa é obrigatório.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(10, 2)")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O valor da despesa deve ser maior que zero.")]
        public decimal Valor { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data da Despesa")]
        public DateTime DataDespesa { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "A categoria da despesa é obrigatória.")]
        [StringLength(100, ErrorMessage = "A categoria da despesa não pode ter mais de 100 caracteres.")]
        public string Categoria { get; set; } = string.Empty; // Valor padrão definido como string vazia
    }
}
