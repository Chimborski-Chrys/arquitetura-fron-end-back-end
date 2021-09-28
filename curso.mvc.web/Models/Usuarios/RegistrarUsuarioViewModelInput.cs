using System.ComponentModel.DataAnnotations;

namespace curso.mvc.web.Models.Usuarios
{
    public class RegistrarUsuarioViewModelInput
    {
        [Required(ErrorMessage = "Login é obrigatório")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Email é obrigatório")]
        [EmailAddress(ErrorMessage ="Email inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha é obrigatório")]
        public string Senha { get; set; }
    }
}
