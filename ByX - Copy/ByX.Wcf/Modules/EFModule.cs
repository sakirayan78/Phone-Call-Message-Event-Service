using System.Data.Entity;

using Autofac;
using ByX.Model;
using ByX.Repository.Common;
using ByX.Repository;


namespace ByX.Wcf.Modules
{
    

    public class EFModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new RepositoryModule());

            builder.RegisterType(typeof(ByXContext)).As(typeof(DbContext)).InstancePerLifetimeScope();
           
            builder.RegisterType(typeof(UnitOfWork)).As(typeof(IUnitOfWork)).SingleInstance().InstancePerDependency();  
        }

    }
}