using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using ByX.Model.Common;

namespace ByX.Model.PhoneBook
{
    public class PhoneBook : AuditableEntity<int>
    {

        public String Name { get; set; }
        public String PhoneNumber { get; set; }

        [ForeignKey("IDF")]
        public virtual PhoneDetail.PhoneDetail PhoneDetail { get; set; }

        public int IDF { get; set; }

       


    }
}
