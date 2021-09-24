using curso.mvc.web.Models.Cursos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace curso.mvc.web.Controllers
{
    public class CursoController : Controller
    {
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(RegistrarCursoViewModelInput registrarCursoViewModelInput)
        {
            return View();
        }

        public IActionResult Listar()
        {
            var cursos = new List<ListarCursoViewModelOutput>
            {
                new ListarCursoViewModelOutput()
                {
                    Nome = "Curso A",
                    Descricao = "Descrição Curso A",
                },

                new ListarCursoViewModelOutput()
                {
                    Nome = "Curso B",
                    Descricao = "Descrição Curso B",
                }
            };
            return View(cursos);
        }


    }
}
