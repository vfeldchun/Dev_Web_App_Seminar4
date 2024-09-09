using Autofac;
using Autofac.Extensions.DependencyInjection;
using LibraryService.Models;
using LibraryService.Models.Dto;
using LibraryService.Repo;

namespace LibraryService
{
    public class Program
    {
        public static WebApplication BuildWebApp(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            var config = new ConfigurationBuilder();
            config.AddJsonFile("appsettings.json");
            var cfg = config.Build();

            builder.Services.AddAutoMapper(typeof(MappingProfile));
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

            builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
            {
                containerBuilder.RegisterType<LibraryRepo>().As<ILibraryRepo>();
                containerBuilder.Register(c => new AppDbContext(cfg.GetConnectionString("db"))).InstancePerDependency();
            });

            return builder.Build();
        }

        public static void Main(string[] args)
        {
            var app = BuildWebApp(args);
            
            app.UseSwagger();
            app.UseSwaggerUI();            

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
