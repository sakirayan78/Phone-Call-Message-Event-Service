using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Autofac;
using  Autofac.Integration.Wcf;
using AutoMapper;
using ByX.Model.CallDetail;
using ByX.Model.MessageDetail;
using ByX.Model.PhoneDetail;
using ByX.Wcf.Modules;



namespace ByX.Wcf
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            //Autofac Configuration//we are registering all dependencys here 
            //


            var builder = new ContainerBuilder();

            builder.RegisterType<Phone>();
          
            //registering dependencys under the "Models" folder
            builder.RegisterModule(new RepositoryModule());
            builder.RegisterModule(new ServiceModule());
            builder.RegisterModule(new EFModule());
            AutofacHostFactory.Container = builder.Build();

            //Mapper.CreateMap<PhoneDetail, ByX.Wcf.Phone.PhoneDetail>();
            Mapper.CreateMap<ByX.Wcf.Phone.PhoneDetail, PhoneDetail>()
                .ForMember(dest => dest.UpdatedBy, opt => opt.Ignore())
                .ForMember(dest=>dest.UpdatedDate,opt=>opt.Ignore())
                .ForMember(dest=>dest.CreatedBy,opt=>opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.User, opt => opt.Ignore())
                .ForMember(dest=>dest.Id,opt=>opt.Ignore()
                ); 

           // Mapper.CreateMap<CallDetail, ByX.Wcf.Phone.CallDetail>();
            Mapper.CreateMap<ByX.Wcf.Phone.CallDetail, CallDetail>()
                .ForMember(dest => dest.UpdatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.PhoneDetail, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore());

          //  Mapper.CreateMap<MessageDetail, ByX.Wcf.Phone.MessageDetail>();
            Mapper.CreateMap<ByX.Wcf.Phone.MessageDetail, MessageDetail>()
                .ForMember(dest => dest.UpdatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.PhoneDetail, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            Mapper.AssertConfigurationIsValid();
         
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}