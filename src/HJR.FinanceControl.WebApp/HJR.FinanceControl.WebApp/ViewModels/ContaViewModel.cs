using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using HJR.FinanceControl.WebApp.Helpers.Enums;

namespace HJR.FinanceControl.WebApp.ViewModels
{
    public abstract class ContaViewModel
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Número do Documento")]
        [Required(ErrorMessage = "O número do documento é obrigatório!")]
        public int Documento { get; set; }

        [DisplayName("Descrição do Documento")]
        [Required(ErrorMessage = "A Descrição do Documento é obrigatória!")]
        public string DescricaoDocumento { get; set; }

        [DisplayName("Data de Vencimento")]
        [Required(ErrorMessage = "A Data de Vencimento é obrigatória!")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime DataVencimento { get; set; }

        [DisplayName("Valor Total")]
        [Required(ErrorMessage = "O Valor Total do documento é obrigatório!")]
        [DataType(DataType.Currency)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:C0}")]
        public float ValorTotal { get; set; }

        [DisplayName("Situação")]
        [Required(ErrorMessage = "A situação do Documento é obrigatória!")]
        public Situacao Situacao { get; set; }
    }
}