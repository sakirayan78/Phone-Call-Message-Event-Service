using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ByX.Model.PhoneDetail;
using ByX.Repository;
using ByX.Repository.Common;
using ByX.Service.Common;

namespace ByX.Service
{
   public class PhoneDetailService:EntityService<PhoneDetail>,IPhoneDetailService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IPhoneDetailRepository _phonedetailRepository;
        public PhoneDetailService(IUnitOfWork unitOfWork, IPhoneDetailRepository phonedetailrepository)
            : base(unitOfWork, phonedetailrepository)
        {
            _unitOfWork = unitOfWork;
            _phonedetailRepository = phonedetailrepository;
        }


        public bool Insert(Model.PhoneDetail.PhoneDetail phonedetail)
        {
            //checking  if this phone is registered before
            var result = (!_phonedetailRepository.FindBy(m => m.DEVICEID == phonedetail.DEVICEID).Any());
            if (!result) return false;
            _phonedetailRepository.Add(phonedetail);
            result = (_unitOfWork.Commit() > 0);
            return result;
        }

        public bool Update(Model.PhoneDetail.PhoneDetail phonedetail)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Model.PhoneDetail.PhoneDetail phonedetail)
        {
            throw new NotImplementedException();
        }

        public Model.PhoneDetail.PhoneDetail Find(int aprtid)
        {
            throw new NotImplementedException();
        }




        public PhoneDetail FindByPhoneUniqeId(string phoneuniqeid)
        {
          return  _phonedetailRepository.FindBy(m => m.DEVICEID == phoneuniqeid).FirstOrDefault();
        }
    }
}
