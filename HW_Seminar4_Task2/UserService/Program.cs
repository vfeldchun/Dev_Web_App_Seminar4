
using Autofac.Extensions.DependencyInjection;
using Autofac;
using UserService.Models.Dto;
using UserService.Repo;
using UserService.Models;

namespace UserService
{
    public class Program
    {
        public static WebApplication BuildWebApp(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            var config = new ConfigurationBuilder();
            config.AddJsonFile("appsettings.json");
            var cfg = config.Build();

            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

            builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
            {
                containerBuilder.RegisterType<UserRepository>().As<IUserRepository>();
                containerBuilder.Register(c => new AppDbContext(cfg.GetConnectionString("db"))).InstancePerDependency();
            });

            return builder.Build();
        }

        public static void Main(string[] args)
        {
            var app = BuildWebApp(args);

            
            app.UseSwagger();
            app.UseSwaggerUI();
            //app.UseSwaggerUI(options =>
            //{
            //    options.SwaggerEndpoint("http://usrhost/swagger/v1/swagger.json", "UserService v1");                
            //});

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            app.Run();
        }
    }
}
