using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WM.Domain.Anuncio.Anuncio.Entities;

namespace WM.Infra.Data.Anuncio.Mappings
{
    public class AnuncioMapping : IEntityTypeConfiguration<AnuncioModel>
    {
        public void Configure(EntityTypeBuilder<AnuncioModel> builder)
        {
            builder.Property(p => p.Id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Marca)
                .HasColumnType("varchar(45)")
                .IsRequired(); ;
            builder.Property(p => p.Modelo)
                .HasColumnType("varchar(45)")
                .IsRequired(); ;
            builder.Property(p => p.Versao)
                .HasColumnType("varchar(45)")
                .IsRequired(); ;

            builder.Property(p => p.Ano)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(p => p.Quilometragem)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(p => p.Observacao)
                .HasColumnType("text")
                .IsRequired();

            builder.Ignore(p => p.ValidationResult);

            builder.Ignore(p => p.CascadeMode);

            builder.ToTable("tb_AnuncioWebmotors");
        }
    }
}