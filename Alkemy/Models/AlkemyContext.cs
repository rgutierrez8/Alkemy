using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alkemy.Models
{
    public class AlkemyContext : DbContext
    {
        public AlkemyContext(DbContextOptions<AlkemyContext> options) : base(options)
        {

        }

        public DbSet<Personaje> Personaje { get; set; }
        public DbSet<PeliculaSerie> PeliculaSeries { get; set; }
        public DbSet<Genero> Genero { get; set; }
    }
}
