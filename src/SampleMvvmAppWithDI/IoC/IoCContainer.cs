using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SampleMvvmAppWithDI.ApplicationLogic.Queries;
using SampleMvvmAppWithDI.DAL;
using SampleMvvmAppWithDI.DTOs.MapperProfiles;
using SampleMvvmAppWithDI.ViewModels.GetData;
using System;
using System.IO;

namespace SampleMvvmAppWithDI.IoC
{
    public static class IoCContainer
    {
        public static IServiceProvider ServiceProvider { get; }

        public static IConfiguration Configuration { get; }

        static IoCContainer()
        {
            var serviceCollection = new ServiceCollection();

            Configuration = AddConfiguration();
            DefineServices(serviceCollection);
            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        private static IConfiguration AddConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: false);

            var configuration = builder.Build();

            return configuration;
        }

        private static void DefineServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DtoProfiles).Assembly);

            services.AddMediatR(typeof(GetSampleDataQuery).Assembly);

            services.AddSingleton(Configuration);

            services.AddSingleton<GetDataViewModel>();

            services.AddTransient<ISampleDataProvider, SampleDataGenerator>();
        }
    }
}
