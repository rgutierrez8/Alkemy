using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Alkemy.Models
{
    public class Genero
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        public string Imagen { get; set; }

        public ICollection<GeneroPelicula> GeneroPelicula { get; set; }
    }
}
