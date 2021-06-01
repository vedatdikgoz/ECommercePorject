using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceProject.Business.Abstract;
using ECommerceProject.Business.Constants;
using ECommerceProject.Business.ValidationRules.FluentValidation;
using ECommerceProject.Core.Aspects.Autofac.Validation;
using ECommerceProject.Core.Utilities.Results;
using ECommerceProject.DataAccess.Abstract;
using ECommerceProject.Entities.Concrete;

namespace ECommerceProject.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductRepository _productRepository;

        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        [ValidationAspect(typeof(ProductValidator))]
        public IDataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(_productRepository.GetAll(), Messages.ProductsListed);

        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productRepository.Get(c=>c.ProductId==productId), Messages.ProductsListed);
        }

        public IDataResult<Product> GetProductDetails(string url)
        {
            return new SuccessDataResult<Product>(_productRepository.GetProductDetails(url), Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetProductsByCategory(string name, int page, int pageSize)
        {
            return new SuccessDataResult<List<Product>>(_productRepository.GetProductsByCategory(name, page, pageSize), Messages.ProductsListed);
        }

        public IResult Add(Product entity)
        {
            _productRepository.Add(entity);

            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Update(Product entity)
        {
            _productRepository.Update(entity);

            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<bool> Update(Product entity, int[] categoryIds)
        {
            _productRepository.Update(entity, categoryIds);
            return new SuccessDataResult<bool>(Messages.ProductAdded);
        }

        public IResult Delete(Product entity)
        {
            _productRepository.Delete(entity);

            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<int> GetCountByCategory(string category)
        {
            return new SuccessDataResult<int>(_productRepository.GetCountByCategory(category),Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetHomePageProducts()
        {
            return new SuccessDataResult<List<Product>>(_productRepository.GetAll().Where(I => I.IsApproved && I.IsHome)
                .ToList());
        }

        public IDataResult<List<Product>> GetSearchResult(string searchString)
        {
            return new SuccessDataResult<List<Product>>(_productRepository.GetAll()
                .Where(I => I.IsApproved && (I.Name.ToLower().Contains(searchString.ToLower()) ||
                                             I.Description.ToLower().Contains(searchString.ToLower())))
                .AsQueryable().ToList());
        }


        public IDataResult<Product> GetByIdWithCategories(int productId)
        {
            return new SuccessDataResult<Product>(_productRepository.GetByIdWithCategories(productId),Messages.ProductsListed);
        }

        public IDataResult<int> CountProduct()
        {
            return new SuccessDataResult<int>(_productRepository.GetAll().Count());
        }

        public IDataResult<string> MaxPriceProduct()
        {
            return new SuccessDataResult<string>(_productRepository.GetAll().OrderByDescending(I => I.Price)
                .Select(I => I.Name).FirstOrDefault());
        }

        public IDataResult<string> MinPriceProduct()
        {
            return new SuccessDataResult<string>(_productRepository.GetAll().OrderBy(I => I.Price)
                .Select(I => I.Name).FirstOrDefault());
        }

        public IDataResult<int> MaxStockProduct()
        {
            return new SuccessDataResult<int>(_productRepository.GetAll().GroupBy(I => I.Brand)
                .OrderByDescending(I => I.Count()).Select(I => I.Key).FirstOrDefault());
        }
    }
}
