using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Alkemy.Models
{
    public class PeliculaSerieDTO
    {
        public string Imagen { get; set; }
        public string Titulo { get; set; }

        [Display(Name = "Fecha de creación")]
        public DateTime FechaCreacion { get; set; }
        public ICollection<GeneroPelicula> GeneroPelicula { get; set; }

    }
}
