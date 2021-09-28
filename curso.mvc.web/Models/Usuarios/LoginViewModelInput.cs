using System.ComponentModel.DataAnnotations;

namespace curso.mvc.web.Models.Usuarios
{
    public class LoginViewModelInput
    {
        [Required(ErrorMessage = "Login é obrigatório")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Senha é obrigatória")]
        public string Senha { get; set; }
    }
}
