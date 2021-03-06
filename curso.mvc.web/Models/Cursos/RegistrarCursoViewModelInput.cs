using System.ComponentModel.DataAnnotations;

namespace curso.mvc.web.Models.Cursos
{
    public class RegistrarCursoViewModelInput
    {
        [Required(ErrorMessage = "Nome do curso é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Descrição do curso é obrigatória")]
        public string Descricao { get; set; }
    }
}
