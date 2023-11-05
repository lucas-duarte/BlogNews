using API.BlogNews.Controllers;
using API.BlogNews.Helpers;
using API.BlogNews.Interfaces;
using API.BlogNews.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace API.BlogNewsTest.Controllers
{
    public class NoticiaControllerTest
    {
        [Fact(DisplayName = "Validando se a noticia é criada com sucesso")]
        [Trait("Categoria", "Validando Controller Noticias")]
        public async Task Create_ShouldReturnOkResult()
        {
            var noticiaServiceMock = new Mock<INoticiaService>();
            var controller = new NoticiaController(noticiaServiceMock.Object);
            var novaNoticia = new Noticia
            {
                Autor = "Lucas Duarte",
                DataPublicacao = DateTime.Now,
                Descricao = "Descrição 1",
                Titulo = "Título 1"
            };


            noticiaServiceMock.Setup(service => service.CreateNoticiaAsync(novaNoticia))
                .ReturnsAsync(new ProviderResult<bool>(true, null));

            var result = await controller.Create(novaNoticia) as OkObjectResult;

            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Trait("Categoria", "Validando Controller Noticias")]
        [Fact(DisplayName = "Validando se a noticia retonam com sucesso por ID")]
        public async Task GetNoticia_ShouldReturnOkResult()
        {
            var noticiaServiceMock = new Mock<INoticiaService>();
            var controller = new NoticiaController(noticiaServiceMock.Object);
            var noticiaId = Guid.NewGuid(); 

            noticiaServiceMock.Setup(service => service.GetNoticiaAsync(noticiaId))
                .ReturnsAsync(new ProviderResult<Noticia>(new Noticia(), null));

            var result = await controller.GetNoticia(noticiaId) as OkObjectResult;

            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Trait("Categoria", "Validando Controller Noticias")]
        [Fact(DisplayName = "Validando se as noticias retonam com sucesso")]
        public async Task GetNoticias_ShouldReturnOkResult()
        {
            var noticiaServiceMock = new Mock<INoticiaService>();
            var controller = new NoticiaController(noticiaServiceMock.Object);

            noticiaServiceMock.Setup(service => service.GetAllNoticiasAsync())
                .ReturnsAsync(new ProviderResult<List<Noticia>>(new List<Noticia>(), null));

            var result = await controller.GetNoticias() as OkObjectResult;

            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }
    }
}
