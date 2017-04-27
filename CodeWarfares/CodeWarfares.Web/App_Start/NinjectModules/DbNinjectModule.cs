using CodeWarfares.Data;
using CodeWarfares.Data.Contracts;
using CodeWarfares.Data.Repositories;
using Ninject.Modules;
using Ninject.Web.Common;

namespace CodeWarfares.Web.App_Start.NinjectModules
{
    public class DbNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Kernel.Bind<ICodeWarfaresDbContext>().To<CodeWarfaresDbContext>().InRequestScope();
            this.Kernel.Bind(typeof(IRepository<>)).To(typeof(GenericRepository<>));
        }
    }
}