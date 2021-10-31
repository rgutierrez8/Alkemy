using Alkemy.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alkemy.Repositories
{
    public class GeneroRepository: RepositoryBase<Genero>, IGeneroRepository
    {
        public GeneroRepository(AlkemyContext repositoryContext) : base(repositoryContext)
        {

        }

        public IEnumerable<Genero> SearchByGenre(string genre)
        {
            var dato = FindAll(source => source.Include(genero => genero.GeneroPelicula)
                                .ThenInclude(peli => peli.PeliculaSerie)).Where(genero => genero.Nombre.Contains(genre)).ToList();

            return dato;
        }
    }
}
