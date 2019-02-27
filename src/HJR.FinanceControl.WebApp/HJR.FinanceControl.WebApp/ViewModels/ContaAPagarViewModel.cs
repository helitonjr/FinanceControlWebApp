using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HJR.FinanceControl.WebApp.ViewModels
{
    public class ContaAPagarViewModel : ContaViewModel
    {
        [DisplayName("Nome do Fornecedor")]
        [Required(ErrorMessage = "O Nome do Fornecedor é obrigatório!")]
        public string Fornecedor { get; set; }
    }
}