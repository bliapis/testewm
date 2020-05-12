using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WM.Domain.Cliente.Clientes.Entities;

namespace WM.Infra.Data.Cliente.Mappings
{
    public class ClienteMapping : IEntityTypeConfiguration<ClienteModel>
    {
        public void Configure(EntityTypeBuilder<ClienteModel> builder)
        {
            builder.Property(p => p.Id)
                .IsRequired();
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .HasColumnType("nvarchar(100)")
                .IsRequired(); ;
            builder.Property(p => p.Idade)
                .HasColumnType("int")
                .IsRequired();

            builder.Ignore(p => p.ValidationResult);

            builder.Ignore(p => p.CascadeMode);

            builder.ToTable("Cliente");
        }
    }
}