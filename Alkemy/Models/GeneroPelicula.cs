using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Alkemy.Models
{
    public class GeneroPelicula
    {
        public int Id { get; set; }

        [ForeignKey("PeliculaSerie")]
        public int PeliculaSerieId { get; set; }
        public PeliculaSerie PeliculaSerie { get; set; }

        [ForeignKey("Genero")]
        public int GeneroId { get; set; }
        public Genero Genero { get; set; }
    }
}
