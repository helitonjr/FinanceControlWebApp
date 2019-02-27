using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HJR.FinanceControl.WebApp.ViewModels
{
    public class ContaAReceberViewModel : ContaViewModel
    {
        [DisplayName("Nome do Cliente")]
        [Required(ErrorMessage = "O Nome do Cliente é obrigatório!")]
        public string Cliente { get; set; }
    }
}