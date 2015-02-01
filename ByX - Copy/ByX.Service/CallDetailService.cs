using System;
using ByX.Model.CallDetail;
using ByX.Repository;
using ByX.Repository.Common;
using ByX.Service.Common;

namespace ByX.Service
{
   public class CallDetailService:EntityService<CallDetail>,ICallDetailService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly ICallDetailRepository _calldetailRepository;
        public CallDetailService(IUnitOfWork unitOfWork, ICallDetailRepository phonedetailrepository)
            : base(unitOfWork, phonedetailrepository)
        {
            _unitOfWork = unitOfWork;
            _calldetailRepository = phonedetailrepository;
        }


        public bool Insert(Model.CallDetail.CallDetail calldetail)
        {


            _calldetailRepository.Add(calldetail);
            bool result = (_unitOfWork.Commit() > 0);
            _unitOfWork.Dispose();
            return result;
        }

        public bool Update(Model.CallDetail.CallDetail calldetail)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Model.CallDetail.CallDetail calldetail)
        {
            throw new NotImplementedException();
        }

        public Model.CallDetail.CallDetail Find(int aprtid)
        {
            throw new NotImplementedException();
        }

        public Model.CallDetail.CallDetail Find(Model.CallDetail.CallDetail calldetail)
        {
            throw new NotImplementedException();
        }
    }
}
