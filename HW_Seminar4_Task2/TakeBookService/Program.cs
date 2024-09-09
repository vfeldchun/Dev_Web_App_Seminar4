using Autofac.Extensions.DependencyInjection;
using Autofac;
using TakeBookService.Models.Dto;
using TakeBookService.Repo;
using TakeBookService.Models;

namespace TakeBookService
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
                containerBuilder.RegisterType<ClientBookRepo>().As<IClientBookRepo>();
                containerBuilder.Register(c => new AppDbContext(cfg.GetConnectionString("db"))).InstancePerDependency();
            });

            return builder.Build();
        }

        public static void Main(string[] args)
        {
            var app = BuildWebApp(args);

            //"id": "3fa85f64-5717-4562-b3fc-2c963f66afa8",
            //"authorId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",

            
            app.UseSwagger();
            app.UseSwaggerUI();
            

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
