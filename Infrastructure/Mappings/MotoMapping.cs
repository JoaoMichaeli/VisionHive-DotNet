using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vision.Hive.Infrastructure.Persistence;

namespace Vision.Hive.Infrastructure.Mappings
{
    public class MotoMapping : IEntityTypeConfiguration<Moto>
    {
        public void Configure(EntityTypeBuilder<Moto> builder)
        {
            builder.ToTable("Motos");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Placa)
                .HasMaxLength(10);

            builder.Property(m => m.Chassi)
                .HasMaxLength(30);

            builder.Property(m => m.NumeroMotor)
                .HasMaxLength(30);

            builder.Property(m => m.Prioridade)
                .IsRequired();


            builder.HasOne(m => m.Patio)
                .WithMany(a => a.Motos)
                .HasForeignKey(m => m.PatioId);
        }
    }
}
