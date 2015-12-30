using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using NetTcpBindingSample.Container;

namespace NetTcpBindingSample.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            if (Environment.UserInteractive)
            {
                Bootstrapper.Initialize();
                Console.WriteLine("Bootstrapper initialized, server ready.");
                Console.ReadLine();

            }
            else
            {
                ServiceBase.Run(new ServiceBase[] { new WcfHostService() });
            }
        }
    }
}
