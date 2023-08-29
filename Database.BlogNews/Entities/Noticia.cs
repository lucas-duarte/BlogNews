using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.BlogNews.Entities
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
}
