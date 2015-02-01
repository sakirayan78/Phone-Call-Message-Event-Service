using System;
using ByX.Model.MessageDetail;
using ByX.Repository;
using ByX.Repository.Common;
using ByX.Service.Common;

namespace ByX.Service
{
   public class MessageDetailService:EntityService<MessageDetail>,IMessageDetailService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMessageDetailRepository _messagedetailRepository;
        public MessageDetailService(IUnitOfWork unitOfWork, IMessageDetailRepository messagedetailrepository)
            : base(unitOfWork, messagedetailrepository)
        {
            _unitOfWork = unitOfWork;
            _messagedetailRepository = messagedetailrepository;
        }


        public bool Insert(Model.MessageDetail.MessageDetail messagedetail)
        {
            _messagedetailRepository.Add(messagedetail);
            bool result = (_unitOfWork.Commit() > 0);
            _unitOfWork.Dispose();
            return result;
        }

        public bool Update(Model.MessageDetail.MessageDetail messagedetail)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Model.MessageDetail.MessageDetail messagedetail)
        {
            throw new NotImplementedException();
        }

        public Model.MessageDetail.MessageDetail Find(int aprtid)
        {
            throw new NotImplementedException();
        }

        public Model.MessageDetail.MessageDetail Find(Model.MessageDetail.MessageDetail messagedetail)
        {
            throw new NotImplementedException();
        }
    }
}
