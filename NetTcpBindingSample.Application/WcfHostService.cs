using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using NetTcpBindingSample.Container;

namespace NetTcpBindingSample.Application
{
    partial class WcfHostService : ServiceBase
    {
        public WcfHostService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
          Bootstrapper.Initialize();
        }

        protected override void OnStop()
        {
            Bootstrapper.DisposeApplication();
        }
    }
}
