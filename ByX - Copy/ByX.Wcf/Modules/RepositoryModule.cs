using System.Reflection;
using Autofac;


namespace ByX.Wcf.Modules
{
    public class RepositoryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.Load("ByX.Repository"))
                   .Where(t => t.Name.EndsWith("Repository"))
                  
                   .AsImplementedInterfaces()
                  .InstancePerLifetimeScope();
            //builder.RegisterType<CacheManager>().As<ICacheManager>().SingleInstance();
        }
    }
}