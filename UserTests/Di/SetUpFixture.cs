using Autofac;
using SpecFlow.Autofac;
using TechTalk.SpecFlow;

namespace UserTests.Di
{
    [Binding]
    internal class SetUpFixture
    {

        [ScenarioDependencies]
        public static ContainerBuilder ScenarioDependencies()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<TestDependenciesModule>();

            return builder;
        }

        [BeforeTestRun]
        public static void BeforeTestRun ()
        {
            var container = ScenarioDependencies().Build();
        }
    }
}
