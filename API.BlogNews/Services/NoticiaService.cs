using API.BlogNews.Helpers;
using API.BlogNews.Interfaces;
using API.BlogNews.Models;
using Database.BlogNews;
using Entities = Database.BlogNews.Entities;
using Microsoft.EntityFrameworkCore;
using Database.BlogNews.Entities;

namespace API.BlogNews.Services
{
    public class NoticiaService : INoticiaService
    {
        private readonly BlogNewsDbContext _dbContext;

        public NoticiaService(BlogNewsDbContext context)
        {
            _dbContext = context;
        }

        public async Task<IProviderResult<bool>> CreateNoticiaAsync(Models.Noticia noticia)
        {
            try
            {
                var entityNoticia = noticia?.Map<Entities.Noticia>();

                await _dbContext.Noticias.AddAsync(entityNoticia);

                var result = await _dbContext.SaveChangesAsync();

                if (result > 0)
                {
                    return new ProviderResult<bool>(true, null);
                }

                return new ProviderResult<bool>(false, "");
            }
            catch (Exception ex)
            {
                return new ProviderResult<bool>(false, ex.Message);
            }
        }

        public async Task<IProviderResult<bool>> DeleteNoticiaAsync(Guid id)
        {
            string error;

            try
            {
                var entity = await _dbContext.Noticias.FindAsync(id);

                if (entity is not null)
                {
                    _dbContext.Noticias.Remove(entity);

                    var result = await _dbContext.SaveChangesAsync();

                    if (result > 0)
                    {
                        return new ProviderResult<bool>(true, null);
                    }

                    error = $"A imagem não foi deletada";

                    return new ProviderResult<bool>(false, error);
                }

                error = $"Não foi possível encontrar Imagem";

                return new ProviderResult<bool>(false, error);
            }
            catch (Exception ex)
            {
                return new ProviderResult<bool>(false, ex.Message);
            }
        }

        public async Task<IProviderResult<List<Models.Noticia>>> GetAllNoticiasAsync()
        {
            try
            {
                var entities = await _dbContext.Noticias.ToListAsync();

                return new ProviderResult<List<Models.Noticia>>(entities.Map<List<Models.Noticia>>(), null);
            }
            catch (Exception ex)
            {
                return new ProviderResult<List<Models.Noticia>>(null, ex.Message);
            }
        }

        public async Task<IProviderResult<Models.Noticia>> GetNoticiaAsync(Guid id)
        {
            try
            {
                var entity = await _dbContext.Noticias.FirstOrDefaultAsync(p => p.Id.Equals(id));

                return new ProviderResult<Models.Noticia>(entity?.Map<Models.Noticia>(), null);
            }
            catch (Exception ex)
            {
                return new ProviderResult<Models.Noticia>(null, ex.Message);
            }
        }

        public async Task<IProviderResult<bool>> UpdateNoticiaAsync(Guid id, Models.Noticia noticia)
        {
            try
            {
                var updatedEntity = noticia?.Map<Entities.Noticia>();

                var currentEntity = await _dbContext.Noticias.FirstOrDefaultAsync(d => d.Id.Equals(noticia.Id));

                if (currentEntity is not null)
                {
                    _dbContext.Entry(currentEntity).CurrentValues.SetValues(updatedEntity);

                    _dbContext.Update(currentEntity);

                    var result = await _dbContext.SaveChangesAsync();

                    if (result > 0)
                    {
                        return new ProviderResult<bool>(true, null);
                    }

                    return new ProviderResult<bool>(false, "Deal has not been updated successfully");
                }

                return new ProviderResult<bool>(false, "Deal not found");
            }
            catch (Exception ex)
            {
                return new ProviderResult<bool>(false, "Deal not found");
            }
        }
    }
}
