using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Alkemy.Models
{
    public class Personaje
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Imagen { get; set; }

        [Required]
        [StringLength(60)]
        [RegularExpression("^[a-zA-Z]$")]
        public string Nombre { get; set; }

        [Required]
        public int Edad { get; set; }

        [Required]
        public float Peso { get; set; }

        [Required]
        [StringLength(500)]
        public string Historia { get; set; }

        [Display(Name = "Películas")]
        public ICollection<PersonajePelicula> PersonajePeliculas{ get; set; }

    }
}
