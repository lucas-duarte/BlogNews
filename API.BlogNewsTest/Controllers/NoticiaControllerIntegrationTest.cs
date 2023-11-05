using API.BlogNews.Models;
using Azure.Core;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace API.BlogNewsTest.Controllers
{
    public class NoticiaControllerIntegrationTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _webApplicationFactory;

        public NoticiaControllerIntegrationTest(WebApplicationFactory<Program> webApplicationFactory)
        {
            _webApplicationFactory = webApplicationFactory;
        }

        [Fact]
        public async Task CreateNoticia_ReturnsOkResult()
        {
            var client = _webApplicationFactory.CreateClient();

            // Dados simulados para o corpo da requisição
            var noticia = new Noticia
            {
                Titulo = "Título da notícia",
                Descricao = "Descrição da notícia",
                Chapeu = "Chapeu da notícia",
                DataPublicacao = DateTime.Now,
                Autor = "Autor da notícia"
            };

            var body = JsonSerializer.Serialize(noticia);
            var stringContent = new StringContent(body, Encoding.UTF8, "application/json");


            // Fazer a requisição HTTP POST para a ação "Create
            var response = await client.PostAsync("api/Noticia/Create", stringContent);


            // Verificar se a resposta é Ok
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public void Test()
        {
            var noticia = new Noticia
            {
                Titulo = "Título da notícia",
                Descricao = "Descrição da notícia",
                Chapeu = "Chapeu da notícia",
                DataPublicacao = DateTime.Now,
                Autor = "Autor da notícia"
            };

            var application = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            var body = JsonSerializer.Serialize(noticia);
            var content = new StringContent(body, Encoding.UTF8, "application/json");
            var client = application.CreateClient();

            var response = client.PostAsync("api/Noticia/Create", content).Result;
        }


        [Fact]
        public void Test2()
        {
            using (HttpClient client = new HttpClient())
            {
                // Dados simulados para o corpo da requisição
                var noticia = new Noticia
                {
                    Titulo = "Título da notícia",
                    Descricao = "Descrição da notícia",
                    Chapeu = "Chapeu da notícia",
                    DataPublicacao = DateTime.Now,
                    Autor = "Autor da notícia"
                };

                var body = JsonSerializer.Serialize(noticia);
                var stringContent = new StringContent(body, Encoding.UTF8, "application/json");


                // Fazer a requisição HTTP POST para a ação "Create
                var response = client.PostAsync("https://blognews-web.azurewebsites.net/api/Noticia/Create", stringContent).Result;


                // Verificar se a resposta é Ok
                Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            }
        }

    }
}
