using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using ByX.Model.Common;

namespace ByX.Model.CallDetail
{
    public class CallDetail : AuditableEntity<int>
    {


        [ForeignKey("IDF")]

        public virtual PhoneDetail.PhoneDetail PhoneDetail { get; set; }
        public int IDF { get; set; }


        public String incomingnumber { get; set; }
        public String CallStartDate { get; set; }
        public String CallEndDate { get; set; }
        public String Type { get; set; }
        public String outgoingNumber { get; set; }



    }
}
