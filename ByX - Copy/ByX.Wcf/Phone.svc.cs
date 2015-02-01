using System;

using System.Runtime.Serialization;

using System.ServiceModel.Activation;


using AutoMapper;
using ByX.Service;


namespace ByX.Wcf
{

    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Phone : IPhone
    {

        private readonly IPhoneDetailService _phoneDetailService;
        private readonly IMessageDetailService _messageDetailService;
        private readonly ICallDetailService _callDetailService;
        private readonly IUserService _userService;


        public Phone(IPhoneDetailService phoneDetailService, IMessageDetailService messageDetailService,
            ICallDetailService callDetailService, IUserService userService)
        {
            _phoneDetailService = phoneDetailService;
            _messageDetailService = messageDetailService;
            _callDetailService = callDetailService;
            _userService = userService;
        }




        public string InsertPhoneEvent(Wrapper wrapper)
        {
            bool succsess = false;

            if (!_userService.IsRegisteredUserHaveUniqueGuidAndExceedQuota(Guid.Parse(wrapper.userUniqGuid)))
            {

                return false.ToString();
            }


            String sendtype = wrapper.sendType;

            //Depends on the type(ss) ,we initiate new class and insert it to corresponded field
            switch (sendtype)
            {
                case "PHONEDETAIL":
                    //that means,phone for the first time record database.so we need to 
                    //call _phoneDetailService.Insert methot

                    // we are mapping here
            
                    var _phoneDetail = new PhoneDetail();
                    _phoneDetail = wrapper.phoneDetail;
                    Model.PhoneDetail.PhoneDetail ph = Mapper.Map<PhoneDetail, Model.PhoneDetail.PhoneDetail>(_phoneDetail);
                    succsess = _phoneDetailService.Insert(ph);
                    break;
                case "CALLDETAIL":
                    //that means,phone get a call activity ,so we need to 
                    //call _callDetailService.Insert methot

                    var _phoneuniqeid= wrapper.phoneUniqId;
                    //we are finding unique phone record
                    var dd=  _phoneDetailService.FindByPhoneUniqeId(_phoneuniqeid);

                    var  ph1 = Mapper.Map<Wcf.Phone.CallDetail,
                     ByX.Model.CallDetail.CallDetail>(wrapper.callDetail);
                    ph1.IDF = dd.Id;
                    succsess = _callDetailService.Insert(ph1);

                    break;
                case "MESSAGEDETAIL":
                    //that means,phone get a message activity so we need to 
                    //call _messageDetailService.Insert methot

                    var _phoneuniqeid2 = wrapper.phoneUniqId;
                    var dd2 = _phoneDetailService.FindByPhoneUniqeId(_phoneuniqeid2);

                    var ph2 = new ByX.Model.MessageDetail.MessageDetail();
                    ph2 = Mapper.Map<Wcf.Phone.MessageDetail,
                        Model.MessageDetail.MessageDetail>(wrapper.messageDetail);
                    ph2.IDF = dd2.Id;
                    succsess = _messageDetailService.Insert(ph2);

                    break;


            }


            return succsess.ToString();

        }




        [DataContract]
        public class Wrapper
        {
            //device id
            [DataMember]
            public string phoneUniqId { get; set; }

            [DataMember]
            public string userUniqGuid { get; set; }

            [DataMember]
            public string sendType { get; set; }
            [DataMember]
            public CallDetail callDetail { get; set; }

            [DataMember]
            public MessageDetail messageDetail { get; set; }

            [DataMember]
            public PhoneDetail phoneDetail { get; set; }
        }


        [DataContract]
        public class PhoneDetail
        {
            [DataMember]
            public String DEVICEID { get; set; }
            [DataMember]

            public String BOARD { get; set; }

            [DataMember]

            public String PHONENUMBER { get; set; }

            [DataMember]
            public String BOOTLOADER { get; set; }
            [DataMember]
            public String BRAND { get; set; }
            [DataMember]
            public String DEVICE { get; set; }
            [DataMember]
            public String DISPLAY { get; set; }
            [DataMember]
            public String FINGERPRINT { get; set; }
            [DataMember]
            public String HARDWARE { get; set; }
            [DataMember]
            public String HOST { get; set; }
            [DataMember]
            // public String ID { get; set; }
            public String MANUFACTURER { get; set; }
            [DataMember]
            public String MODEL { get; set; }
            [DataMember]
            public String PRODUCT { get; set; }
            [DataMember]

            public String TYPE { get; set; }
           
              [DataMember]
            public Guid UserUniqueId { get; set; }
        }

        [DataContract]
        public class MessageDetail
        {

            [DataMember]
            public int IDF { get; set; }
            [DataMember]
            public String SenderNumber { get; set; }
            [DataMember]
            public String Message { get; set; }
        }

        [DataContract]
        public class CallDetail
        {
            [DataMember]
            public int IDF { get; set; }
            [DataMember]
            public String incomingnumber { get; set; }
            [DataMember]
            public String CallStartDate { get; set; }
            [DataMember]
            public String CallEndDate { get; set; }
            [DataMember]
            public String Type { get; set; }
            [DataMember]
            public String outgoingNumber { get; set; }
        }


    }
}
