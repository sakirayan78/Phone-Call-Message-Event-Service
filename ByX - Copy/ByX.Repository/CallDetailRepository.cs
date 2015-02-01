using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using ByX.Model.CallDetail;
using ByX.Model.PhoneDetail;
using ByX.Repository.Common;

namespace ByX.Repository
{
   public class CallDetailRepository : GenericRepository<CallDetail>, ICallDetailRepository
    {
       public CallDetailRepository(DbContext context)
            : base(context)
        {
        }
    }
}
