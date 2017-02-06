using CodeWarfares.Data;
using CodeWarfares.Data.Contracts;
using CodeWarfares.Data.Repositories;
using Ninject.Modules;

namespace CodeWarfares.Web.App_Start.NinjectModules
{
    public class DbNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Kernel.Bind<ICodeWarfaresDbContext>().To<CodeWarfaresDbContext>().InSingletonScope();
            this.Kernel.Bind(typeof(IRepository<>)).To(typeof(GenericRepository<>));
        }
    }
}