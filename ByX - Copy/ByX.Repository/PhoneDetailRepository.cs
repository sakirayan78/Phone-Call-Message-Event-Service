using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using  ByX.Model.PhoneDetail;
using  ByX.Repository.Common;

namespace ByX.Repository
{
  public  class PhoneDetailRepository : GenericRepository<PhoneDetail>, IPhoneDetailRepository
    {
        public PhoneDetailRepository(DbContext context)
            : base(context)
        {

        }
    }
}
