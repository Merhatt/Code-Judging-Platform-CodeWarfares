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
    using System.Web.UI.WebControls;
    using Data.Services.Contracts.Account;
    using Data.Services.Account;
    using Presenters.Account.Contracts;
    using Presenters.Account;
    using Presenters;
    using Presenters.Factories;
    using Data.Models.Factories;
    using Data.Models.Contracts;
    using Data.Models;
    using Presenters.Contracts.Account;

    public static class NinjectWebCommon
    {
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
                return kernel;
            }
            catch
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
            kernel.Bind(b => b.From("CodeWarfares.Data")
                .SelectAllClasses()
                .BindDefaultInterfaces());

            kernel.Bind(b => b.From("CodeWarfares.Data.Models")
                .SelectAllClasses()
                .BindDefaultInterfaces());

            kernel.Bind(b => b.From("CodeWarfares.Data.Services")
                .SelectAllClasses()
                .BindDefaultInterfaces());

            kernel.Bind(b => b.From("CodeWarfares.Data.Web")
               .SelectAllClasses()
               .BindDefaultInterfaces());

            //Classes and Intefaces
            kernel.Bind<ILoginView>().To<Account.Login>();

            //Factories
            kernel.Bind<ILoginPresenterFactory>().ToFactory().InRequestScope();
            kernel.Bind<IUserFactory>().ToFactory().InSingletonScope();
            kernel.Bind<IRegisterPresenterFactory>().ToFactory().InRequestScope();

            //Presenters
            kernel.Bind<ILoginPresenter>().To<LoginPresenter>();
            kernel.Bind<IRegisterPresenter>().To<RegisterPresenter>()
                                            .WithConstructorArgument("userFactory", kernel.Get<IUserFactory>());
        }
    }
}
