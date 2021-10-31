using Alkemy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alkemy.Repositories
{
    public interface IGeneroRepository
    {
        IEnumerable<Genero> SearchByGenre(string genre);
    }
}
