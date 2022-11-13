[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(MvcProjeKampi.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(MvcProjeKampi.App_Start.NinjectWebCommon), "Stop")]

namespace MvcProjeKampi.App_Start
{
    using System;
    using System.Web;
    using DataAccessLayer.Abstract;
    using DataAccessLayer.Concrete;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using BusinessLayer.Concrete;

    using Ninject;
    using Ninject.Web.Common;
    using BusinessLayer.Abstract;

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

                kernel.Bind<ICategoryService>().To<CategoryManager>().InSingletonScope();
                kernel.Bind<ICategoryDal>().To<EFCategoryDal>().InSingletonScope();

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
        }        
    }
}
