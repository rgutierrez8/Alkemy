using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Alkemy.Models
{
    public class PeliculaSerie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Imagen { get; set; }

        [Required]
        [StringLength(120)]
        public string Titulo { get; set; }

        [Required]
        [Display(Name = "Fecha de creación")]
        public DateTime FechaCreacion { get; set; }

        [Required]
        public double Calificacion { get; set; }

        [Display(Name = "Personajes")]
        public ICollection<PersonajePelicula> PersonajesPelicula { get; set; }
        public ICollection<GeneroPelicula> GeneroPelicula { get; set; }
    }
}
