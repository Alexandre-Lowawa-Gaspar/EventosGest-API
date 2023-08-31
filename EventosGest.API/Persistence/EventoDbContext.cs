using EventosGest.API.Entites;
using Microsoft.EntityFrameworkCore;

namespace EventosGest.API.Persistence
{
    public class EventoDbContext : DbContext
    {
        public EventoDbContext(DbContextOptions<EventoDbContext> options) : base(options)
        {

        }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<EventoOrador> Oradores { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Evento>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Titulo).IsRequired(false);
                e.Property(x => x.Descricao).IsRequired(false).
                HasMaxLength(200).
                HasColumnType("varchar(200)");
                e.Property(x => x.Inicio).HasColumnName("Inicio");
                e.Property(x => x.Termino).HasColumnName("Termino");
                e.HasMany(x => x.Oradores).WithOne().HasForeignKey(s => s.EventoId);
            });
            builder.Entity<EventoOrador>(e =>
            {
                e.HasKey(x => x.Id);
            });
        }
    }
}
