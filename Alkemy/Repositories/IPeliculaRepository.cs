using Alkemy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alkemy.Repositories
{
    public interface IPeliculaRepository
    {
        IEnumerable<PeliculaSerie> GetAllMovies();
        IEnumerable<PeliculaSerie> SearchByName(string nombre, string order);
        PeliculaSerie MovieDetails(string nombre);
    }
}
