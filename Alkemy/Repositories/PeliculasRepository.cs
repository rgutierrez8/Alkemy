using Alkemy.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alkemy.Repositories
{
    public class PeliculasRepository: RepositoryBase<PeliculaSerie>, IPeliculaRepository
    {
        public PeliculasRepository(AlkemyContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<PeliculaSerie> GetAllMovies()
        {
            return FindAll(source => source.Include(pers => pers.PersonajesPelicula)
                .ThenInclude(pp => pp.PeliculaSerie)
                    .ThenInclude(gp => gp.GeneroPelicula)
                        .ThenInclude(gen => gen.Genero)).OrderBy(pelicula => pelicula.Id).ToList();
        }

        public IEnumerable<PeliculaSerie> SearchByName(string nombre, string order)
        {
            if(order == "asc")
            {
                return FindAll(source => source.Include(pers => pers.PersonajesPelicula)
                    .ThenInclude(pp => pp.PeliculaSerie)
                    .ThenInclude(pp => pp.GeneroPelicula)
                        .ThenInclude(gen => gen.Genero)).Where(peli => peli.Titulo.Contains(nombre)).OrderBy(peli => peli.FechaCreacion).ToList();
            }
            else if(order == "desc")
            {
                return FindAll(source => source.Include(pers => pers.PersonajesPelicula)
                    .ThenInclude(pp => pp.PeliculaSerie)
                    .ThenInclude(pp => pp.GeneroPelicula)
                        .ThenInclude(gen => gen.Genero)).Where(peli => peli.Titulo.Contains(nombre)).OrderByDescending(peli => peli.FechaCreacion).ToList();
            }
            else
            {
                return FindAll(source => source.Include(pers => pers.PersonajesPelicula)
                    .ThenInclude(pp => pp.PeliculaSerie)
                    .ThenInclude(pp => pp.GeneroPelicula)
                        .ThenInclude(gen => gen.Genero)).Where(peli => peli.Titulo.Contains(nombre)).OrderBy(peli => peli.Id).ToList();
            }
        }
        public PeliculaSerie MovieDetails(string titulo)
        {
            var dato = FindByCondition(movie => movie.Titulo == titulo)
                    .Include(peli => peli.PersonajesPelicula)
                        .ThenInclude(pp => pp.Personaje).FirstOrDefault();

            return dato;
        }

        
    }
}
