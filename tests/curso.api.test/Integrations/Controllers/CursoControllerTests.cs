using AutoBogus;
using curso.api.Models.Cursos;
using curso.api.Models.Usuarios;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;


namespace curso.api.test.Integrations.Controllers
{
    public class CursoControllerTests : UsuarioControllerTests
    {
        public CursoControllerTests(WebApplicationFactory<Startup> factory, ITestOutputHelper output) :base(factory, output)
        {

        }

        [Fact]
        public async Task Registrar_InformandoDadosDeUmCursoValidoEUmUsuarioAutenticado_DeveretornarSucesso()
        {
            //Arrange
            var cursoViewModelInput = new AutoFaker<CursoViewModelInput>();
            // .RuleFor(p => p.Email, faker => faker.Person.Email);

            StringContent content = new StringContent(JsonConvert.SerializeObject(cursoViewModelInput), Encoding.UTF8, "application/json");

            //Act
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LoginViewModelOutput.Token);
            var httpClientRequest = await _httpClient.PostAsync("api/v1/cursos", content);
            //Assert
            Assert.Equal(HttpStatusCode.Created, httpClientRequest.StatusCode);

        }

        public async Task Registrar_InformandoDadosDeUmCursoValidoEUmUsuarioNaoAutenticado_DeveretornarSucesso()
        {
            //Arrange
            var cursoViewModelInput = new AutoFaker<CursoViewModelInput>();
            // .RuleFor(p => p.Email, faker => faker.Person.Email);

            StringContent content = new StringContent(JsonConvert.SerializeObject(cursoViewModelInput), Encoding.UTF8, "application/json");

            //Act
            var httpClientRequest = await _httpClient.PostAsync("api/v1/cursos", content);
            //Assert
            Assert.Equal(HttpStatusCode.Unauthorized, httpClientRequest.StatusCode);

        }

        [Fact]
        public async Task Obter_InformandoUmUsuarioAutenticado_DeveretornarSucesso()
        {
            //Arrange
            await Registrar_InformandoDadosDeUmCursoValidoEUmUsuarioAutenticado_DeveretornarSucesso();

            //Act
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LoginViewModelOutput.Token);
            var httpClientRequest = await _httpClient.GetAsync("api/v1/cursos");

            //Assert
            var cursos = JsonConvert.DeserializeObject<IList<CursoViewModelOutput>>(await httpClientRequest.Content.ReadAsStringAsync());
            Assert.NotNull(cursos);

            Assert.Equal(HttpStatusCode.OK, httpClientRequest.StatusCode);

        }
    }
}
