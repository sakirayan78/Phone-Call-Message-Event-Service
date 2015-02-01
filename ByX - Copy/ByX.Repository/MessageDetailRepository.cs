using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using ByX.Model.CallDetail;
using ByX.Model.MessageDetail;
using ByX.Model.PhoneDetail;
using ByX.Repository.Common;

namespace ByX.Repository
{
   public class MessageDetailRepository : GenericRepository<MessageDetail>, IMessageDetailRepository
    {
       public MessageDetailRepository(DbContext context)
            : base(context)
        {
        }
    }
}
