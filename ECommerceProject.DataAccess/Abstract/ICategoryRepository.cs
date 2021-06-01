using System;
using System.Collections.Generic;
using System.Text;
using ECommerceProject.Core.DataAccess;
using ECommerceProject.Entities.Concrete;


namespace ECommerceProject.DataAccess.Abstract
{
    public interface ICategoryRepository:IEntityRepository<Category>
    {
        Category GetByIdWithProducts(int categoryId);
        void DeleteFromCategory(int productId, int categoryId);
    }
}
