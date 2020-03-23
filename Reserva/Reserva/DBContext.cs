using Microsoft.EntityFrameworkCore;
using Reserva.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reserva
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions opciones) : base(opciones)
        {

        }

        public virtual DbSet<Complejo> Complejo { get; set; }
        public virtual DbSet<Cancha> Cancha { get; set; }
        public virtual DbSet<Reservaciones> Reservacion { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Equipo> Equipo { get; set; }
        public virtual DbSet<Torneo> Torneo { get; set; }
        public virtual DbSet<Admin> Admin { get; set; }



        protected override void OnModelCreating(ModelBuilder mb)
        {
            new Complejo.Map(mb.Entity<Complejo>());
            new Cancha.Map(mb.Entity<Cancha>());
            new Reservaciones.Map(mb.Entity<Reservaciones>());
            new Usuario.Map(mb.Entity<Usuario>());
            new Equipo.Map(mb.Entity<Equipo>());
            new Torneo.Map(mb.Entity<Torneo>());
            new Admin.Map(mb.Entity<Admin>());
            base.OnModelCreating(mb);
        }


    }
}
