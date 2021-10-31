using Alkemy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alkemy.Repositories
{
    public interface IPersonajePeliculaRepository
    {
        IEnumerable<PersonajePelicula> Search(string name, int idMovie);
    }
}
