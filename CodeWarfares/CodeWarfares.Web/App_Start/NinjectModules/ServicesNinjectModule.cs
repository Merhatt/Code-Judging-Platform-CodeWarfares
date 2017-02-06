using Ninject.Extensions.Conventions;
using Ninject.Modules;

namespace CodeWarfares.Web.App_Start.NinjectModules
{
    public class ServicesNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Kernel.Bind(b => b.From("CodeWarfares.Data.Services")
                .SelectAllClasses()
                .BindDefaultInterfaces());
        }
    }
}