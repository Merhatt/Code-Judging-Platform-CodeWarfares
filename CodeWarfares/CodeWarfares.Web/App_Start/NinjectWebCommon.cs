[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(CodeWarfares.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(CodeWarfares.Web.App_Start.NinjectWebCommon), "Stop")]

namespace CodeWarfares.Web.App_Start
{
    using System;
    using System.Web;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Extensions.Factory;
    using Ninject.Extensions.Conventions;
    using Views.Contracts.Account;
    using Presenters.Account.Contracts;
    using Presenters.Account;
    using Data.Models.Factories;
    using Presenters.Contracts.Account;
    using Data.Contracts;
    using Data.Repositories;
    using Data;
    using Presenters.Contracts.MasterPages;
    using Presenters.MasterPages;
    using WebFormsMvp.Binder;
    using NinjectModules;
    using Presenters.Contracts.Codings;
    using Presenters.Codings;
    using Account;
    using Views.Contracts.Coding;
    using Codings;

    public static class NinjectWebCommon
    {
        public static IKernel NinjectKernel;
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);

                NinjectKernel = kernel;

                return kernel;
            }
            catch (Exception ex)
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Load(new MvpNinjectModule());

            PresenterBinder.Factory = kernel.Get<IPresenterFactory>();

            kernel.Bind(b => b.From("CodeWarfares.Data.Models")
                .SelectAllClasses()
                .BindDefaultInterfaces());

            kernel.Bind(b => b.From("CodeWarfares.Data.Services")
                .SelectAllClasses()
                .BindDefaultInterfaces());

            kernel.Bind(b => b.From("CodeWarfares.Data.Web")
               .SelectAllClasses()
               .BindDefaultInterfaces());

            kernel.Bind(b => b.From("CodeWarfares.Utils")
               .SelectAllClasses()
               .BindDefaultInterfaces());

            //Classes and Intefaces
            kernel.Bind<ILoginView>().To<Login>();
            kernel.Bind<IRegisterView>().To<Register>();
            kernel.Bind<IRegisterView>().To<Register>();
            kernel.Bind<ICompetitionsView>().To<Competitions>();
            kernel.Bind<ICompetitionsCategoryView>().To<CompetitionsCategory>();
            kernel.Bind<ICodeWarfaresDbContext>().To<CodeWarfaresDbContext>().InSingletonScope();
            kernel.Bind(typeof(IRepository<>)).To(typeof(GenericRepository<>));


            //Factories
            kernel.Bind<IUserFactory>().ToFactory().InSingletonScope();
            kernel.Bind<ISubmitionFactory>().ToFactory().InSingletonScope();
            kernel.Bind<ITestCompletedFactory>().ToFactory().InSingletonScope();

            //Presenters
            kernel.Bind<ILoginPresenter>().To<LoginPresenter>();
            kernel.Bind<IRegisterPresenter>().To<RegisterPresenter>();
            kernel.Bind<ICompetitionsPresenter>().To<CompetitionsPresenter>();
            kernel.Bind<ISiteMasterPresenter>().To<SiteMasterPresenter>();
            kernel.Bind<ICompetitionsCategoryPresenter>().To<CompetitionsCategoryPresenter>();
        }
    }
}
