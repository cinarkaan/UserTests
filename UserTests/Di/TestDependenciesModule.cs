using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserTests.Clients;
using UserTests.Steps;
using UserTests.Utils;
using WalletTests.Clients;

namespace UserTests.Di
{
    public class TestDependenciesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserServiceClient>().As<IUserServiceClient>().AsSelf();

            builder.RegisterType<WalletServiceClient>().AsSelf().SingleInstance();
            
            builder.RegisterType<UserAssertSteps>().AsSelf();
            
            builder.RegisterType<UserSteps>().AsSelf();

            builder.RegisterType<WalletSteps>().AsSelf();

            builder.RegisterType<WalletAssertSteps>().AsSelf();

            builder.RegisterType<UserGenerator>().AsSelf();

            builder.RegisterType<WalletCharger>().AsSelf();

            builder.RegisterType<Context>().AsSelf().SingleInstance();
        }
    }

}
