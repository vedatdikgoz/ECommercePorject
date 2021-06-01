using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ECommerceProject.Core.DataAccess.EntityFramework;
using ECommerceProject.DataAccess.Abstract;
using ECommerceProject.DataAccess.Concrete.Context;
using ECommerceProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;


namespace ECommerceProject.DataAccess.Concrete.EntityFramework
{
    public class EfCategoryRepository : EfEntityRepositoryBase<Category, DataContext>, ICategoryRepository
    {

        public Category GetByIdWithProducts(int categoryId)
        {
            using var context = new DataContext();
            return context.Categories.Where(I => I.CategoryId == categoryId)
                .Include(I => I.ProductCategories)
                .ThenInclude(I => I.Product).FirstOrDefault();
        }

        public void DeleteFromCategory(int productId, int categoryId)
        {
            using var context = new DataContext();
            var cmd = "delete from productcategories where ProductId=@p0 and CategoryId=@p1";
            context.Database.ExecuteSqlRaw(cmd, productId, categoryId);
        }

       
    }
}
