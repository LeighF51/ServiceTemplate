using System;
using System.Threading.Tasks;
using Autofac;
using NetCoreServicePackageTemplate.Client;
using NetCoreServicePackageTemplate.Interfaces;

namespace NetCoreServicePackageTemplate
{
    public class AutofacModule : Module
    {
        protected override  void Load(ContainerBuilder builder)
        { 
            builder.RegisterType<ServiceClient>().As<IServiceClient>();
        }
    }
}
