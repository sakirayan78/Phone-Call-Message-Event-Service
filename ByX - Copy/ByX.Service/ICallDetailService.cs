using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ByX.Model.CallDetail;


namespace ByX.Service
{
  public  interface ICallDetailService
    {
        bool Insert(CallDetail phonedetail);
        bool Update(CallDetail phonedetail);
        bool Delete(CallDetail phonedetail);
        CallDetail Find(int aprtid);
        CallDetail Find(CallDetail phonedetail);
    }
}
