using Eventec.Domain;
using EvenTec.Domain;
using Microsoft.EntityFrameworkCore;

namespace EvenTec.Persistence
{
    public class EventecContext : DbContext
    {
        public EventecContext(DbContextOptions<EventecContext> options) : base(options){ }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<Palestrante> Palestrantes { get; set; }
        public DbSet<PalestranteEvento> PalestrantesEventos { get; set; }
        public DbSet<RedeSocial> RedesSociais { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PalestranteEvento>()
                .HasKey(PE => new {PE.EventoID, PE.PalestranteID});
        }
    }
}