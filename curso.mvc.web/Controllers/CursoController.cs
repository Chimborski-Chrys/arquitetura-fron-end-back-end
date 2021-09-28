using curso.mvc.web.Models.Cursos;
using curso.mvc.web.Services;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace curso.mvc.web.Controllers
{
    public class CursoController : Controller
    {
        private readonly ICursoService _cursoService;

        public CursoController(ICursoService cursoService)
        {
            _cursoService = cursoService;
        }
        public IActionResult Cadastrar()
        {
           
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Cadastrar(RegistrarCursoViewModelInput registrarCursoViewModelInput)
        {
            try
            {
                var curso = await _cursoService.Registrar(registrarCursoViewModelInput);
                ModelState.AddModelError("", "Curso cadastrado com sucesso");

            }
            catch (ApiException ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
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
