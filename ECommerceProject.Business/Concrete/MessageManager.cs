using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ECommerceProject.Business.Abstract;
using ECommerceProject.Business.Constants;
using ECommerceProject.Core.Utilities.Results;
using ECommerceProject.DataAccess.Abstract;
using ECommerceProject.Entities.Concrete;

namespace ECommerceProject.Business.Concrete
{
    public class MessageManager : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        public MessageManager(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public IDataResult<Message> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Message>> GetAll()
        {
            return new SuccessDataResult<List<Message>>(_messageRepository.GetAll());
        }

        public IResult Add(Message entity)
        {
            _messageRepository.Add(entity);

            return new SuccessResult(Messages.MessageAdded);
        }

        public IResult Update(Message entity)
        {
            _messageRepository.Update(entity);

            return new SuccessResult(Messages.MessageAdded);
        }

        public IResult Delete(Message entity)
        {
            _messageRepository.Delete(entity);

            return new SuccessResult(Messages.MessageAdded);
        }

        public IDataResult<List<Message>> GetMessageDetail(int id)
        {
            return new SuccessDataResult<List<Message>>(_messageRepository.GetAll().Where(I => I.MessageId == id)
                .ToList());
        }
    }
}
