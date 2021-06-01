using System;
using System.Collections.Generic;
using System.Text;
using ECommerceProject.Core.Utilities.Results;
using ECommerceProject.Entities.Concrete;

namespace ECommerceProject.Business.Abstract
{
    public interface IMessageService
    {
        IDataResult<Message> GetById(int id);
        IDataResult<List<Message>> GetAll();
        IResult Add(Message entity);
        IResult Update(Message entity);
        IResult Delete(Message entity);
        IDataResult<List<Message>> GetMessageDetail(int id);
    }
}
