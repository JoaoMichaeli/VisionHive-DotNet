using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vision.Hive.Infrastructure.Persistence;

namespace Vision.Hive.Infrastructure.Mappings
{
    public class FilialMapping: IEntityTypeConfiguration<Filial>
    {
        public void Configure(EntityTypeBuilder<Filial> builder)
        {
            builder
                .ToTable("Filiais");

            builder
                .HasKey(f => f.Id);

            builder
                .Property(f => f.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(f => f.Bairro)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(f => f.Cnpj)
                .IsRequired()
                .HasMaxLength(20);

            builder
                .HasMany(f => f.Patios)
                .WithOne(p => p.Filial)
                .HasForeignKey(p => p.FilialId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
