using AWSApiSegundoExamenAgus.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWSApiSegundoExamenAgus.Data
{
    public class ConciertoContext:DbContext
    {
        public ConciertoContext(DbContextOptions<ConciertoContext> options) : base(options) { }

        public DbSet<CategoriaEvento> CategoriaEventos { get; set; }

        public DbSet<Evento> Eventos { get; set; }
    }
}
