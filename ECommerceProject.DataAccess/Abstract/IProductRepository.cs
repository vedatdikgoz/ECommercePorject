using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceProject.Core.DataAccess;
using ECommerceProject.Core.Utilities.Results;
using ECommerceProject.Entities.Concrete;

namespace ECommerceProject.DataAccess.Abstract
{
    public interface IProductRepository : IEntityRepository<Product>
    {
        Product GetProductDetails(string url);
        List<Product> GetProductsByCategory(string name, int page, int pageSize);
        int GetCountByCategory(string category);
        Product GetByIdWithCategories(int productId);
        void Update(Product entity, int[] categoryIds);
    }
}
