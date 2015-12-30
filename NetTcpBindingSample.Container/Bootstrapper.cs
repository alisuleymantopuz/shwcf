using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Windsor;
using NetTcpBindingSample.Container.Installers;

namespace NetTcpBindingSample.Container
{
    public class Bootstrapper
    {
        public static IWindsorContainer Container { get; set; }

        public static void Initialize()
        {
            Container = new WindsorContainer();
            Container
                .Install(new RepositoryInstaller())
                .Install(new ManagerInstaller())
                .Install(new AssemblerInstaller())
                .Install(new ServiceInstaller());

        }

        public static void DisposeApplication()
        {
        }
    }
}
