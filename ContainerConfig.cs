using Autofac;
using Microsoft.Extensions.Configuration;
using ShebawsCoreLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShebawsCore
{
    public static class ContainerConfig
    {        
        public static IContainer Configure()
        { 
            var builder = new ContainerBuilder();
            builder.RegisterType<ShebawsService>().As<IShebawsService>();
            return builder.Build();
        }
    }
}
