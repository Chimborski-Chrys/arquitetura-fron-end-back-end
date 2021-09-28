using curso.mvc.web.Models.Usuarios;
using curso.mvc.web.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Refit;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace curso.mvc.web.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(RegistrarUsuarioViewModelInput registrarUsuarioViewModelInput)
        {
            try
            {
                var usuario = await _usuarioService.Registrar(registrarUsuarioViewModelInput);
                ModelState.AddModelError("", "Dados cadastrados com sucesso para o login");
            }
            catch(ApiException ex)
            {
                ModelState.AddModelError("",ex.Message);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }


            /*
            var clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            var httpClient = new HttpClient(clientHandler);
            httpClient.BaseAddress = new System.Uri("https://localhost:5001");

            var registrarUsuarioViewModelInputJson = JsonConvert.SerializeObject(registrarUsuarioViewModelInput);
            var httpContent = new StringContent(registrarUsuarioViewModelInputJson, Encoding.UTF8, "application/json");

            var httpPost = httpClient.PostAsync("/api/v1/usuario/registrar", httpContent).GetAwaiter().GetResult();

             if(httpPost.StatusCode == System.Net.HttpStatusCode.Created)
            {
                ModelState.AddModelError("", "Dados cadastrados com sucesso");
            }
            else
            {
                ModelState.AddModelError("", "Erro ao cadastrar");
            }
            */
            return View();
        }

    
        public IActionResult Logar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logar(LoginViewModelInput loginViewModelInput)
        {
            try
            {
                var usuario = await _usuarioService.Logar(loginViewModelInput);
                ModelState.AddModelError("", "Dados cadastrados com sucesso para o login");
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
    }
}
