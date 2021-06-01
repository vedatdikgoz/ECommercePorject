using System;
using System.Collections.Generic;
using System.Text;
using ECommerceProject.Business.Abstract;
using ECommerceProject.Business.Constants;
using ECommerceProject.Core.Utilities.Results;
using ECommerceProject.DataAccess.Abstract;
using ECommerceProject.Entities.Concrete;

namespace ECommerceProject.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryRepository _categoryRepository;

        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IDataResult<Category> GetById(int id)
        {
            return new SuccessDataResult<Category>(_categoryRepository.Get(c => c.CategoryId == id), Messages.CategoriesListed);
        }

        public IDataResult<Category> GetByIdWithProducts(int categoryId)
        {
            return new SuccessDataResult<Category>(_categoryRepository.GetByIdWithProducts(categoryId));
        }

        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryRepository.GetAll(), Messages.CategoriesListed);
        }

        public IResult Add(Category entity)
        {
            _categoryRepository.Add(entity);

            return new SuccessResult(Messages.CategoryAdded);
        }

        public IResult Update(Category entity)
        {
            _categoryRepository.Update(entity);

            return new SuccessResult(Messages.CategoryAdded);
        }

        public IResult Delete(Category entity)
        {
            _categoryRepository.Delete(entity);

            return new SuccessResult(Messages.CategoryAdded);
        }

        public IResult DeleteFromCategory(int productId, int categoryId)
        {
            _categoryRepository.DeleteFromCategory(productId,categoryId);
            return new SuccessResult(Messages.DeleteFromCategory);
        }

        public IDataResult<int> CountCategory()
        {
            return new SuccessDataResult<int>(_categoryRepository.GetAll().Count);
        }
    }
}
