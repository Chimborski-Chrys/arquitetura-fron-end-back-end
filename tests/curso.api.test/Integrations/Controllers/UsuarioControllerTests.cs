using AutoBogus;
using curso.api.Models.Usuarios;
using curso.api.test.Configurations;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace curso.api.test.Integrations.Controllers
{
    public class UsuarioControllerTests : IClassFixture<WebApplicationFactory<Startup>>, IAsyncLifetime
    {
        private readonly WebApplicationFactory<Startup> _factory;
        protected readonly ITestOutputHelper _output;
        protected readonly HttpClient _httpClient;
        protected RegistroViewModelInput RegistroViewModelInput;
        protected LoginViewModelOutput LoginViewModelOutput;
        public UsuarioControllerTests(WebApplicationFactory<Startup> factory, ITestOutputHelper output)
        {
            _factory = factory;
            _output = output; 
            _httpClient = factory.CreateClient();
        }

        public async Task DisposeAsync()
        {
            _httpClient.Dispose();
        }

        public async Task InitializeAsync()
        {
           await Registrar_InformandoUsuarioESenha_DeveretornarSucesso();
            await Logar_InformandoUsuarioESenhaExistentes_DeveretornarSucesso();
        }

        [Fact]
        public async Task Logar_InformandoUsuarioESenhaExistentes_DeveretornarSucesso()
        {
            //Arrange
            var loginViewModelInput = new LoginViewModelInput
            {
                Login = RegistroViewModelInput.Login,
                Senha = RegistroViewModelInput.Senha
            };
            
            StringContent content = new StringContent(JsonConvert.SerializeObject(loginViewModelInput), Encoding.UTF8,"application/json");

            //Act
            var httpClientRequest = await _httpClient.PostAsync("api/v1/usuario/logar", content);

            LoginViewModelOutput = JsonConvert.DeserializeObject<LoginViewModelOutput>(await httpClientRequest.Content.ReadAsStringAsync());
         
            //Assert
            Assert.Equal(HttpStatusCode.OK, httpClientRequest.StatusCode);
            Assert.NotNull(LoginViewModelOutput.Token);
            Assert.Equal(loginViewModelInput.Login, LoginViewModelOutput.Usuario.Login);
        }

        [Fact]
        public async Task Registrar_InformandoUsuarioESenha_DeveretornarSucesso()
        {
            //Arrange
            RegistroViewModelInput = new AutoFaker<RegistroViewModelInput>(AutoBogusConfiguration.LOCATE)
                                            .RuleFor(p => p.Email, faker => faker.Person.Email);

            StringContent content = new StringContent(JsonConvert.SerializeObject(RegistroViewModelInput), Encoding.UTF8, "application/json");

            //Act
            var httpClientRequest = await _httpClient.PostAsync("aapi/v1/usuario/registrar", content);

            //Assert
            Assert.Equal(HttpStatusCode.Created, httpClientRequest.StatusCode);

        }

    }
}
