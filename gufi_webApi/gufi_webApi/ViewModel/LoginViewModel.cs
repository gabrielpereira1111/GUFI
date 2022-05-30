using System.ComponentModel.DataAnnotations;

namespace gufi_webApi.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe seu e-mail!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "Informe sua senha!")]
        [DataType(DataType.Password)]
        public string Senha { get; set; } = null!;
    }
}
