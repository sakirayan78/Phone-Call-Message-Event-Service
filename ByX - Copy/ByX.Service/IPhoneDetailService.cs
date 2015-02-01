using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ByX.Model.PhoneDetail;

namespace ByX.Service
{
  public  interface IPhoneDetailService
    {
        bool Insert(PhoneDetail phonedetail);
        bool Update(PhoneDetail phonedetail);
        bool Delete(PhoneDetail phonedetail);
        PhoneDetail Find(int aprtid);
        //PhoneDetail Find(PhoneDetail phonedetail);
        PhoneDetail FindByPhoneUniqeId(string phoneuniqeid);
    }
}
