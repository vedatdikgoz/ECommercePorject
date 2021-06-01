using ECommerceProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ECommerceProject.DataAccess.Concrete.EntityFramework.Mapping
{
    public class ProductCategoryMap : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {

            builder.HasKey(I => new {I.ProductId, I.CategoryId});
        }
    }
}
