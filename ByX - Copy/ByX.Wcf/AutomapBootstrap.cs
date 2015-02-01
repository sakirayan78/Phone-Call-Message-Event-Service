using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using ByX.Model.CallDetail;
using ByX.Model.MessageDetail;
using ByX.Model.PhoneDetail;
using  ByX.Wcf;

namespace ByX.Wcf
{
    public class AutomapBootstrap
    {
        public static void InitializeMap()
        {
            Mapper.CreateMap<PhoneDetail, ByX.Wcf.Phone.PhoneDetail>();
            Mapper.CreateMap<ByX.Wcf.Phone.PhoneDetail, PhoneDetail>();

            Mapper.CreateMap<CallDetail, ByX.Wcf.Phone.CallDetail>();
            Mapper.CreateMap<ByX.Wcf.Phone.CallDetail, CallDetail>();

            Mapper.CreateMap<MessageDetail, ByX.Wcf.Phone.MessageDetail>();
            Mapper.CreateMap<ByX.Wcf.Phone.MessageDetail, MessageDetail>();

        }
    }
}