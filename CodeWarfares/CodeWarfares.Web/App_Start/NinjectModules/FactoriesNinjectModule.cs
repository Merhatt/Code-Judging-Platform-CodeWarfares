using CodeWarfares.Data.Models.Factories;
using Ninject.Extensions.Factory;
using Ninject.Modules;

namespace CodeWarfares.Web.App_Start.NinjectModules
{
    public class FactoriesNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Kernel.Bind<IUserFactory>().ToFactory().InSingletonScope();
            this.Kernel.Bind<ISubmitionFactory>().ToFactory().InSingletonScope();
            this.Kernel.Bind<ITestCompletedFactory>().ToFactory().InSingletonScope();
        }
    }
}