using System;
using System.Collections.Generic;
using System.Text;
using ECommerceProject.Core.DataAccess;
using ECommerceProject.Entities.Concrete;

namespace ECommerceProject.DataAccess.Abstract
{
    public interface IMessageRepository : IEntityRepository<Message>
    {
    }
}
