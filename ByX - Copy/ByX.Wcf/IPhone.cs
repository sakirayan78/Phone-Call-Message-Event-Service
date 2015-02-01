using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ByX.Model.PhoneDetail;
using Newtonsoft.Json.Linq;

namespace ByX.Wcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPhone" in both code and config file together.
    [ServiceContract]
    public interface IPhone
    {

        [OperationContract]
        [WebInvoke(Method = "POST",
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json,
                 // BodyStyle = WebMessageBodyStyle.Wrapped,
                   UriTemplate = "InsertPhoneEvent")]
        String InsertPhoneEvent(Phone.Wrapper wrapper);


        
    }
}
