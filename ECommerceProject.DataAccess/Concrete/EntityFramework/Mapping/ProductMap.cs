using ECommerceProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ECommerceProject.DataAccess.Concrete.EntityFramework.Mapping
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(I => I.ProductId);
            builder.Property(I => I.ProductId).UseIdentityColumn();
            builder.Property(I => I.Name).HasMaxLength(100).IsRequired();
            builder.Property(I => I.Description).HasMaxLength(300).IsRequired();
            builder.Property(I => I.ImageUrl).HasMaxLength(300);

           

            builder.HasMany(I => I.ProductCategories).WithOne(I => I.Product).HasForeignKey(I => I.ProductId);


        }
    }
}
