using GraphQl.Client;
using GraphQl.Mutations;
using GraphQl.Queries;


namespace GraphQl
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();            

            builder.Services.AddGraphQLServer()
                .AddQueryType<QueryDb>()
                .AddMutationType<ProductMutation>();

            builder.Services.AddTransient<IDbWebClient, DbWebClient>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapGraphQL();

            app.MapControllers();

            app.Run();
        }
    }
}
