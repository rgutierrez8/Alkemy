using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alkemy.Models
{
    public class ListaPersonajes
    {
        public ICollection<PersonajeDTO> Personajes { get; set; }
    }
}
