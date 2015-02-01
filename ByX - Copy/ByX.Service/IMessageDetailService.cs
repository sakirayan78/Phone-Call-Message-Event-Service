using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ByX.Model.MessageDetail;

namespace ByX.Service
{
  public  interface IMessageDetailService
    {
        bool Insert(MessageDetail phonedetail);
        bool Update(MessageDetail phonedetail);
        bool Delete(MessageDetail phonedetail);
        MessageDetail Find(int aprtid);
        MessageDetail Find(MessageDetail phonedetail);
    }
}
