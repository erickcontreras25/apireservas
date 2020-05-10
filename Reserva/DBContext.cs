using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Reserva.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reserva
{
    public class DBContext : IdentityDbContext<ApplicationUser>
    {
        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Complejo> Complejo { get; set; }
        public virtual DbSet<Cancha> Cancha { get; set; }
        public virtual DbSet<Reservaciones> Reservacion { get; set; }
        public virtual DbSet<Equipo> Equipo { get; set; }
        public virtual DbSet<Torneo> Torneo { get; set; }
        public virtual DbSet<EquipoUser> EquipoUser { get; set; }
        public virtual DbSet<TorneoEquipo> TorneoEquipo { get; set; }



        protected override void OnModelCreating(ModelBuilder mb)
        {
            new Complejo.Map(mb.Entity<Complejo>());
            new Cancha.Map(mb.Entity<Cancha>());
            new Reservaciones.Map(mb.Entity<Reservaciones>());
            new Equipo.Map(mb.Entity<Equipo>());
            new Torneo.Map(mb.Entity<Torneo>());

            mb.Entity<EquipoUser>().HasKey(x => new { x.equipoId, x.userId });
            mb.Entity<TorneoEquipo>().HasKey(x => new { x.torneoId, x.equipoId });

            base.OnModelCreating(mb);
        }


    }
}
