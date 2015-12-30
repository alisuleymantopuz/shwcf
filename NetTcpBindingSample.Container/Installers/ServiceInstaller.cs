using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Xml;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Facilities.WcfIntegration;
using NetTcpBindingSample.Services;

namespace NetTcpBindingSample.Container.Installers
{
    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility<WcfFacility>();

            container.Register(
                    Component.For<IServiceBehavior>()
                    .Instance(new ServiceBehaviorAttribute()
                    {
                        InstanceContextMode = InstanceContextMode.PerCall,
                        IncludeExceptionDetailInFaults = true
                    }));

            container.Register(
                Component.For<IServiceBehavior>()
                .Instance(new ServiceThrottlingBehavior()
                {
                    MaxConcurrentCalls = 1000,
                    MaxConcurrentInstances = 1000,
                    MaxConcurrentSessions = 1000
                })
                );

            container.Register(AllTypes.FromAssemblyContaining<CategoryService>()
                           .Pick().If(type => type.GetInterfaces().Any(t => t.Name.EndsWith("Assembler")))
                           .WithService.DefaultInterfaces()
                           .Configure(configurer => configurer.Named(configurer.Implementation.Name).LifestylePerWcfOperation())

                 );



            container.Register(
                    AllTypes.FromAssemblyContaining<CategoryService>()
                        .Pick().If(type => type.GetInterfaces().Any(i => i.IsDefined(typeof(ServiceContractAttribute), true)))
                    .Configure(configurer => configurer
                        .Named(configurer.Implementation.Name)
                        .LifestyleTransient()
                        .AsWcfService(
                            new DefaultServiceModel()
                                .AddEndpoints(
                                    WcfEndpoint
                                        .BoundTo(new NetTcpBinding
                                        {
                                            MaxBufferPoolSize = int.MaxValue,
                                            MaxBufferSize = int.MaxValue,
                                            MaxConnections = 1000,
                                            MaxReceivedMessageSize = int.MaxValue,
                                            ListenBacklog = int.MaxValue,

                                            ReceiveTimeout = TimeSpan.FromMilliseconds(252000),
                                            SendTimeout = TimeSpan.FromMilliseconds(252000),
                                            CloseTimeout = TimeSpan.FromMilliseconds(252000),
                                            OpenTimeout = TimeSpan.FromMilliseconds(252000),

                                            TransactionFlow = false,
                                            TransferMode = TransferMode.Buffered,
                                            TransactionProtocol = TransactionProtocol.OleTransactions,

                                            PortSharingEnabled = true,

                                            Security = new NetTcpSecurity
                                            {
                                                Mode = SecurityMode.None,
                                                Message = new MessageSecurityOverTcp() { ClientCredentialType = MessageCredentialType.None },
                                                Transport = new TcpTransportSecurity() { ProtectionLevel = ProtectionLevel.None }
                                            },

                                            ReliableSession = new OptionalReliableSession
                                            {
                                                Enabled = false
                                            },

                                            ReaderQuotas = new XmlDictionaryReaderQuotas()
                                            {
                                                MaxDepth = int.MaxValue,
                                                MaxArrayLength = int.MaxValue,
                                                MaxStringContentLength = int.MaxValue,
                                                MaxBytesPerRead = int.MaxValue,
                                                MaxNameTableCharCount = int.MaxValue
                                            }
                                        })
                                        .At("net.tcp://" + "127.0.0.1" + ":" + "6016" + "/" + configurer.Implementation.Name)
                                )
                                .PublishMetadata()
                        //.LogMessages()
                        )
                    )
                    .WithService.Select(
                        (Type type, Type[] baseTypes) =>
                            type.GetInterfaces().Where(i => i.IsDefined(typeof(ServiceContractAttribute), true)).Select(x => x as Type)));

        }
    }
}
//net.tcp://localhost:6016/CategoryService etc.