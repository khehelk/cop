using Contracts.StoragesContracts;
using DatabaseImplement.Implements;
using Microsoft.Extensions.DependencyInjection;

namespace UI
{
    internal static class Program
    {
        private static ServiceProvider? _serviceProvider;
        public static ServiceProvider? ServiceProvider => _serviceProvider;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var services = new ServiceCollection();
            ConfigureService(services);
            _serviceProvider = services.BuildServiceProvider();

            Application.Run(_serviceProvider.GetRequiredService<FormMain>());
        }

        private static void ConfigureService(IServiceCollection services)
        {
            services.AddTransient<IProviderStorage, ProviderStorage>();
            services.AddTransient<ITypeStorage, TypeStorage>();
            services.AddTransient<FormMain>();
            services.AddTransient<FormProvider>();
            services.AddTransient<FormType>();
        }
    }
}