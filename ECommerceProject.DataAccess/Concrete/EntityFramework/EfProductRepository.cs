using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceProject.Core.DataAccess.EntityFramework;
using ECommerceProject.DataAccess.Abstract;
using ECommerceProject.DataAccess.Concrete.Context;
using ECommerceProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace ECommerceProject.DataAccess.Concrete.EntityFramework
{
    public class EfProductRepository : EfEntityRepositoryBase<Product, DataContext>, IProductRepository
    {
        public Product GetProductDetails(string url)
        {
            using var context = new DataContext();
            return context.Products.Where(I => I.Url == url).Include(I => I.ProductCategories)
                .ThenInclude(I => I.Category).FirstOrDefault();
        }

        public List<Product> GetProductsByCategory(string name, int page, int pageSize)
        {
            using var context = new DataContext();
            var products = context.Products.Where(I => I.IsApproved).AsQueryable();
            if (!string.IsNullOrEmpty(name))
            {
                products = products.Include(I => I.ProductCategories)
                    .ThenInclude(c => c.Category)
                    .Where(p => p.ProductCategories.Any(c => c.Category.Url == name));
            }

            return products.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }

        public int GetCountByCategory(string category)
        {
            using var context = new DataContext();
            var products = context.Products
                .Where(I => I.IsApproved)
                .AsQueryable();
            if (!string.IsNullOrEmpty(category))
            {
                products = products.Include(I => I.ProductCategories)
                    .ThenInclude(I => I.Category)
                    .Where(I => I.ProductCategories.Any(I => I.Category.Url == category));
            }

            return products.Count();
        }

        public Product GetByIdWithCategories(int productId)
        {
            using var context = new DataContext();
            return context.Products.Where(I => I.ProductId == productId)
                .Include(I => I.ProductCategories)
                .ThenInclude(I => I.Category).FirstOrDefault();
        }


        public void Update(Product entity, int[] categoryIds)
        {
            using var context = new DataContext();
            var product = context.Products.Include(I => I.ProductCategories)
                .FirstOrDefault(I => I.ProductId == entity.ProductId);

            if (product != null)
            {
                product.Name = entity.Name;
                product.Price = entity.Price;
                product.Description = entity.Description;
                product.Url = entity.Url;
                product.ImageUrl = entity.ImageUrl;
                product.IsApproved = entity.IsApproved;
                product.IsHome = entity.IsHome;

                product.ProductCategories = categoryIds.Select(catId => new ProductCategory()
                {
                    ProductId = entity.ProductId,
                    CategoryId = catId
                }).ToList();

                context.SaveChanges();
            }
        }
    }
}