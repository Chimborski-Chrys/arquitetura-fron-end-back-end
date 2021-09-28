using curso.mvc.web.Models.Cursos;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace curso.mvc.web.Services
{
    public interface ICursoService
    {
        [Post("​/api/v1/cursos")]
        Task<RegistrarCursoViewModelOutput> Registrar(RegistrarCursoViewModelInput registrarCursoViewModelInput);
    }
}
