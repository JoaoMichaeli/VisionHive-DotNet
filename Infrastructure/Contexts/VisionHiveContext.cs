using Microsoft.EntityFrameworkCore;
using Vision.Hive.Infrastructure.Mappings;
using Vision.Hive.Infrastructure.Persistence;

namespace Vision.Hive.Infrastructure.Contexts
{
    public class VisionHiveContext(DbContextOptions<VisionHiveContext> options) : DbContext(options)
    {
        public DbSet<Filial> Filiais { get; set; }
        public DbSet<Patio> Patios { get; set; }
        public DbSet<Moto> Motos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FilialMapping());
            modelBuilder.ApplyConfiguration(new PatioMapping());
            modelBuilder.ApplyConfiguration(new MotoMapping());

        }
    }
}
