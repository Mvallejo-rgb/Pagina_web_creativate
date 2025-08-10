using Microsoft.EntityFrameworkCore;
using Parkease.Models.Entidades;

namespace Parkease.Models
{
    public class AplicationDBcontext : DbContext
    {
        public AplicationDBcontext(DbContextOptions<AplicationDBcontext> options) : base(options)
        {
        }

        
        public DbSet<Conductor> Conductor { get; set; }
        //public DbSet<Administrador> Administrador { get; set; }
        public DbSet<Factura> Factura { get; set; }
        //public DbSet<Parqueadero> Parqueadero { get; set; }
        public DbSet<Reserva> Reserva{ get; set; }
        public DbSet<Vehiculo> Vehiculo { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Conductor>().ToTable("conductor");
            //modelBuilder.Entity<Administrador>().ToTable("administrador");
            modelBuilder.Entity<Factura>().ToTable("factura");
            //modelBuilder.Entity<Parqueadero>().ToTable("parqueadero");
            modelBuilder.Entity<Reserva>().ToTable("reserva");
            modelBuilder.Entity<Vehiculo>().ToTable("vehiculo");
        }
    }
}