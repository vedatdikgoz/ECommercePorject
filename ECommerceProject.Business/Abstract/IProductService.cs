using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceProject.Core.Utilities.Results;
using ECommerceProject.Entities.Concrete;

namespace ECommerceProject.Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();
        IDataResult<Product> GetById(int productId);
        IDataResult<Product> GetProductDetails(string url);
        IDataResult<List<Product>> GetProductsByCategory(string name, int page, int pageSize);
        IResult Add(Product entity);
        IResult Update(Product entity);
        IDataResult<bool> Update(Product entity, int[] categoryIds);
        IResult Delete(Product entity);
        IDataResult<int> GetCountByCategory(string category);
        IDataResult<List<Product>> GetHomePageProducts();
        IDataResult<List<Product>> GetSearchResult(string searchString);
        IDataResult<Product> GetByIdWithCategories(int productId);


        IDataResult<int> CountProduct();
        IDataResult<string> MaxPriceProduct();
        IDataResult<string> MinPriceProduct();
        IDataResult<int> MaxStockProduct();

    }
}
