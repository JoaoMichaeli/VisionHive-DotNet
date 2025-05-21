using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vision.Hive.Infrastructure.Persistence;

namespace Vision.Hive.Infrastructure.Mappings
{
    public class PatioMapping: IEntityTypeConfiguration<Patio>
    {
        public void Configure(EntityTypeBuilder<Patio> builder)
        {
            builder.ToTable("Patios");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                  .IsRequired()
                  .HasMaxLength(100);

            builder.Property(p => p.LimiteMotos)
                   .IsRequired();

            builder.HasOne(p => p.Filial)
                   .WithMany(f => f.Patios)
                   .HasForeignKey(p => p.FilialId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.Motos)
                   .WithOne(m => m.Patio)
                   .HasForeignKey(m => m.PatioId)
                   .OnDelete(DeleteBehavior.Cascade);


        }
    }
    
}
