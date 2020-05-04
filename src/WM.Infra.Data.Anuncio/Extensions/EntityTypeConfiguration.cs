using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WM.Infra.Data.Anuncio.Extensions
{
    public abstract class EntityTypeConfiguration<TEntity> where TEntity : class
    {
        public abstract void Map(EntityTypeBuilder<TEntity> builder);
    }
}