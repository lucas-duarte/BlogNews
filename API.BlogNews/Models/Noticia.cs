using Entities = Database.BlogNews.Entities;

namespace API.BlogNews.Models
{
    public class Noticia
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Chapeu { get; set; }
        public DateTime DataPublicacao { get; set; }
        public string Autor { get; set; }
    }

    public class NoticiaProfile : AutoMapper.Profile
    {
        public NoticiaProfile()
        {
            CreateMap<Entities.Noticia, Noticia>();
            CreateMap<Noticia, Entities.Noticia>();
        }
    }
}
