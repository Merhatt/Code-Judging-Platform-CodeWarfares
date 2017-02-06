using Ninject.Extensions.Conventions;
using Ninject.Modules;

namespace CodeWarfares.Web.App_Start.NinjectModules
{
    public class UtilsNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Kernel.Bind(b => b.From("CodeWarfares.Utils")
                .SelectAllClasses()
                .BindDefaultInterfaces());
        }
    }
}