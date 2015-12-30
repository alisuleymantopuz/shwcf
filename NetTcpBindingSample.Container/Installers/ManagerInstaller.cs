using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.MicroKernel.SubSystems.Configuration;
using NetTcpBindingSample.Domain.ProductAggregate;

namespace NetTcpBindingSample.Container.Installers
{
   public class ManagerInstaller :IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<ICategoryManager>().ImplementedBy<CategoryManager>().LifestyleTransient());
        }
    }
}
