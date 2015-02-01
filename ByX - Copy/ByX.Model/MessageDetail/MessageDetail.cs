using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using ByX.Model.Common;

namespace ByX.Model.MessageDetail
{
    public class MessageDetail : AuditableEntity<int>
    {

        [ForeignKey("IDF")]

        public virtual PhoneDetail.PhoneDetail PhoneDetail { get; set; }
        public int IDF { get; set; }

        public String SenderNumber { get; set; }
        public String Message { get; set; }
    }
}
