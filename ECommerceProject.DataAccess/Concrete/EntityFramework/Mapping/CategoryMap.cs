using ECommerceProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ECommerceProject.DataAccess.Concrete.EntityFramework.Mapping
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {

            builder.HasKey(I => I.CategoryId);
            builder.Property(I => I.CategoryId).UseIdentityColumn();

            builder.Property(I => I.Name).HasMaxLength(100).IsRequired();

            builder.HasMany(I => I.ProductCategories).WithOne(I => I.Category).HasForeignKey(I => I.CategoryId);
        }
    }
}
