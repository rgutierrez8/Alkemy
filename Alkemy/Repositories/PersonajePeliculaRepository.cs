using Alkemy.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alkemy.Repositories
{
    public class PersonajePeliculaRepository: RepositoryBase<PersonajePelicula>, IPersonajePeliculaRepository
    {
        public PersonajePeliculaRepository(AlkemyContext repositoryContext): base(repositoryContext)
        {

        }

        public IEnumerable<PersonajePelicula> Search(string name, int idMovie)
        {
            var data = FindAll(source => source.Include(pp => pp.Personaje))
                            .Where(pp => pp.Personaje.Nombre.Contains(name) && pp.PeliculaSerieId == idMovie).OrderBy(pp => pp.PersonajeId).ToList();
            return data;
        }
    }
}
