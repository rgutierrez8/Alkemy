using Alkemy.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alkemy.Repositories
{
    public class GeneroPeliculaRepository: RepositoryBase<GeneroPelicula>, IGeneroPeliculaRepository
    {
        public GeneroPeliculaRepository(AlkemyContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<GeneroPelicula> SearchByGenre(string genre, string title, string order)
        {
            if (order == "asc")
            {
               return FindAll(source => source.Include(gp => gp.PeliculaSerie)).Where(gp => gp.Genero.Nombre.Contains(genre) && gp.PeliculaSerie.Titulo.Contains(title))
                        .OrderBy(peli => peli.PeliculaSerie.FechaCreacion).ToList();
            }
            else if(order == "desc")
            {
               return FindAll(source => source.Include(gp => gp.PeliculaSerie)).Where(gp => gp.Genero.Nombre.Contains(genre) && gp.PeliculaSerie.Titulo.Contains(title))
                        .OrderByDescending(peli => peli.PeliculaSerie.FechaCreacion).ToList();
            }
            else
            {
                return FindAll(source => source.Include(gp => gp.PeliculaSerie)).Where(gp => gp.Genero.Nombre.Contains(genre) && gp.PeliculaSerie.Titulo.Contains(title))
                        .OrderBy(peli => peli.Id).ToList();
            }
        }
    }
}
