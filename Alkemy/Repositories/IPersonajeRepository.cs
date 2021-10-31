using Alkemy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alkemy.Repositories
{
    public interface IPersonajeRepository
    {
        IEnumerable<Personaje> GetAllCharacters();
        IEnumerable<Personaje> SearchByName(string name, int age, float weight);
    }
}
