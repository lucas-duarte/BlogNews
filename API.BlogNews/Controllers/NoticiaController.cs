using API.BlogNews.Interfaces;
using API.BlogNews.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace API.BlogNews.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class NoticiaController : Controller
    {
        private readonly INoticiaService _NoticiaService;

        public NoticiaController(INoticiaService noticiaService)
        {
            _NoticiaService = noticiaService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(Models.Noticia noticia)
        {
            var result = await _NoticiaService.CreateNoticiaAsync(noticia);

            if (String.IsNullOrEmpty(result.ErrorMessage))
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.ErrorMessage);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNoticia(Guid id)
        {
            var result = await _NoticiaService.GetNoticiaAsync(id);

            if (String.IsNullOrEmpty(result.ErrorMessage))
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.ErrorMessage);
            }
        }

        [HttpGet("List")]
        public async Task<IActionResult> GetNoticias()
        {
            var result = await _NoticiaService.GetAllNoticiasAsync();

            if (String.IsNullOrEmpty(result.ErrorMessage))
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.ErrorMessage);
            }
        }
    }
}
