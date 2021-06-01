using System;
using System.Collections.Generic;
using System.Text;
using ECommerceProject.Core.Utilities.Results;
using ECommerceProject.Entities.Concrete;
using FluentValidation;

namespace ECommerceProject.Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<Category> GetById(int id);
        IDataResult<Category> GetByIdWithProducts(int categoryId);
        IDataResult<List<Category>> GetAll();
        IResult Add(Category entity);
        IResult Update(Category entity);
        IResult Delete(Category entity);
        IResult DeleteFromCategory(int productId, int categoryId);
        IDataResult<int> CountCategory();
    }
}
