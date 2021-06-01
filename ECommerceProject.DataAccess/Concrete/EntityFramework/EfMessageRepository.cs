using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ECommerceProject.Core.DataAccess.EntityFramework;
using ECommerceProject.DataAccess.Abstract;
using ECommerceProject.DataAccess.Concrete.Context;
using ECommerceProject.Entities.Concrete;

namespace ECommerceProject.DataAccess.Concrete.EntityFramework
{
    public class EfMessageRepository : EfEntityRepositoryBase<Message, DataContext>, IMessageRepository
    {
        
    }
}
