using Alkemy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alkemy.Repositories
{
    public interface IGeneroPeliculaRepository
    {
        IEnumerable<GeneroPelicula> SearchByGenre(string genre, string title, string order);
    }
}
