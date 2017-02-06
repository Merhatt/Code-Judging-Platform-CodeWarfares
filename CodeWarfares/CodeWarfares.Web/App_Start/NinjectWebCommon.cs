[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(CodeWarfares.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(CodeWarfares.Web.App_Start.NinjectWebCommon), "Stop")]

namespace CodeWarfares.Web.App_Start
{
    using System;
    using System.Web;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using WebFormsMvp.Binder;
    using NinjectModules;

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

            kernel.Load(new DateModelsNinjectModule());

            kernel.Load(new ServicesNinjectModule());

            kernel.Load(new UtilsNinjectModule());

            kernel.Load(new ViewsNinjectModule());

            kernel.Load(new DbNinjectModule());

            kernel.Load(new FactoriesNinjectModule());

            kernel.Load(new PresentersNinjectModule());
        }
    }
}
