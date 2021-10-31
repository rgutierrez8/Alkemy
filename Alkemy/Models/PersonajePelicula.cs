using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Alkemy.Models
{
    public class PersonajePelicula
    {
        public int Id { get; set; }

        [ForeignKey("Personaje")]
        public int PersonajeId { get; set; }
        public Personaje Personaje { get; set; }

        [ForeignKey("PeliculaSerie")]
        public int PeliculaSerieId { get; set; }
        public PeliculaSerie PeliculaSerie { get; set; }
    }
}
