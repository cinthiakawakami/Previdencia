[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(DesafioPrevidencia.MVC.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(DesafioPrevidencia.MVC.App_Start.NinjectWebCommon), "Stop")]

namespace DesafioPrevidencia.MVC.App_Start
{
    using System;
    using System.Web;
    using DesafioPrevidencia.Aplicacao;
    using DesafioPrevidencia.Aplicacao.Interfaces;
    using DesafioPrevidencia.Data.Repositorios;
    using DesafioPrevidencia.Dominio.Interfaces.Repositorios;
    using DesafioPrevidencia.Dominio.Interfaces.Servicos;
    using DesafioPrevidencia.Dominio.Servicos;
    using DesafioPrevidencia.MVC.AutoMapper;
    using global::AutoMapper;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

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
            kernel.Bind(typeof(IAplicacaoBase<>)).To(typeof(AplicacaoBase<>));
            kernel.Bind<ICarteiraAplicacao>().To<CarteiraAplicacao>();
            kernel.Bind<IUsuarioAplicacao>().To<UsuarioAplicacao>();
            kernel.Bind<ISolicitacaoAplicacao>().To<SolicitacaoAplicacao>();
            kernel.Bind<IRespostasFormularioAplicacao>().To<RespostasFormularioAplicacao>();
            kernel.Bind<IPerfilInvestidorAplicacao>().To<PerfilInvestidorAplicacao>();

            kernel.Bind(typeof(IServicoBase<>)).To(typeof(ServicoBase<>));
            kernel.Bind<ICarteiraServico>().To<CarteiraServico>();
            kernel.Bind<IUsuarioServico>().To<UsuarioServico>();
            kernel.Bind<ISolicitacaoServico>().To<SolicitacaoServico>();
            kernel.Bind<IRespostasFormularioServico>().To<RespostasFormularioServico>();
            kernel.Bind<IPerfilInvestidorServico>().To<PerfilInvestidorServico>();

            kernel.Bind(typeof(IRepositorioBase<>)).To(typeof(RepositorioBase<>));
            kernel.Bind<ICarteiraRepositorio>().To<CarteiraRepositorio>();
            kernel.Bind<IUsuarioRepositorio>().To<UsuarioRepositorio>();
            kernel.Bind<ISolicitacaoRepositorio>().To<SolicitacaoRepositorio>();
            kernel.Bind<IRespostasFormularioRepositorio>().To<RespostasFormularioRepositorio>();
            kernel.Bind<IPerfilInvestidorRepositorio>().To<PerfilInvestidorRepositorio>();

            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DominioPraModelMappingProfile>();
                cfg.AddProfile<ModelParaDominioMappingProfile>();
            });
            kernel.Bind<IMapper>().ToConstructor(c => new Mapper(mapperConfiguration)).InSingletonScope();
        }
    }
}
