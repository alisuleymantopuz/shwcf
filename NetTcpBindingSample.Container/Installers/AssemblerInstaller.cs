using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.MicroKernel.SubSystems.Configuration;
using NetTcpBindingSample.Services.Assemblers;

namespace NetTcpBindingSample.Container.Installers
{
    public class AssemblerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<ICategoryServiceAssembler>().ImplementedBy<CategoryServiceAssembler>().LifestyleTransient());
        }
    }
}
