using API.BlogNews.Models;

namespace API.BlogNews.Interfaces
{
    public interface INoticiaService
    {
        public Task<IProviderResult<bool>> CreateNoticiaAsync(Noticia noticia);
        public Task<IProviderResult<Noticia>> GetNoticiaAsync(Guid id);
        public Task<IProviderResult<List<Noticia>>> GetAllNoticiasAsync();
        public Task<IProviderResult<bool>> UpdateNoticiaAsync(Guid id, Noticia noticia);
        public Task<IProviderResult<bool>> DeleteNoticiaAsync(Guid id);

    }
}
