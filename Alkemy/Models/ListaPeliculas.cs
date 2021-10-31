using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alkemy.Models
{
    public class ListaPeliculas
    {
        public ICollection<PeliculaSerieDTO> PeliculaSeries { get; set; }
    }
}
