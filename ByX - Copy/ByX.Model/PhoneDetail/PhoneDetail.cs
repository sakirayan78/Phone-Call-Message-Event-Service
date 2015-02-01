using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using ByX.Model.Common;

namespace ByX.Model.PhoneDetail
{
    //This class based Android Build class
    //http://developer.android.com/reference/android/os/Build.html
  public  class PhoneDetail:AuditableEntity<int>
    {


      
      
        public String DEVICEID { get; set; }
        public String BOARD { get; set; }
        public String BOOTLOADER { get; set; }
        public String BRAND { get; set; }
        public String DEVICE { get; set; }
        public String DISPLAY { get; set; }
        public String FINGERPRINT { get; set; }
        public String HARDWARE { get; set; }
        public String HOST { get; set; }
       // public String ID { get; set; }
        public String MANUFACTURER { get; set; }
        public String MODEL { get; set; }
        public String PRODUCT { get; set; }
      
        public String TYPE { get; set; }
     
        public String PHONENUMBER { get; set; }


        [ForeignKey("UserUniqueId")]
        public  virtual User User { get; set; }
        public Guid UserUniqueId { get; set; }
     


    }
}
