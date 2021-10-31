using Alkemy.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alkemy.Repositories
{
    public class PersonajeRepository: RepositoryBase<Personaje>, IPersonajeRepository
    {

        public PersonajeRepository(AlkemyContext repositoryContext) : base(repositoryContext)
        {
        }
        public IEnumerable<Personaje> GetAllCharacters()
        {
            return FindAll(source => source.Include(peli => peli.PersonajePeliculas)
                .ThenInclude(pp => pp.Personaje)).OrderBy(personaje => personaje.Id).ToList();
        }

        public IEnumerable<Personaje> SearchByName(string name, int age, float weight)
        {
            if(age > 0)
            {
                return FindAll(source => source.Include(pp => pp.PersonajePeliculas)
                       .ThenInclude(p => p.Personaje)).Where(p => p.Nombre.Contains(name) && p.Edad == age)
                           .OrderBy(p => p.Id).ToList();
            }
            else if(weight > 0)
            {
                return FindAll(source => source.Include(pp => pp.PersonajePeliculas)
                    .ThenInclude(p => p.Personaje)).Where(p => p.Nombre.Contains(name) && p.Peso == weight)
                        .OrderBy(p => p.Id).ToList();
            }
            return FindAll(source => source.Include(pp => pp.PersonajePeliculas)
                    .ThenInclude(p => p.Personaje)).Where(p => p.Nombre.Contains(name)).OrderBy(p => p.Id).ToList();
        }
    }
}
