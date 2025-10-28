using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MesaListo.Models;

namespace MesaListo.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // Definición de DbSets para las entidades
        public DbSet<Mesa> Mesas { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Resenia> Resenias { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Restricciones opcionales o configuraciones adicionales
            builder.Entity<Mesa>()
                .HasOne(m => m.Restaurante)
                .WithMany(u => u.Mesas)
                .HasForeignKey(m => m.RestauranteID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Reserva>()
                .HasOne(r => r.Cliente)
                .WithMany(u => u.Reservas)
                .HasForeignKey(r => r.ClienteID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Resenia>()
                .HasOne(r => r.Cliente)
                .WithMany(u => u.Resenias)
                .HasForeignKey(r => r.ClienteID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
