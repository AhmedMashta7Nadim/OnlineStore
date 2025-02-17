using Auth.Authentication_Models;
using Hangfire;
using InfraStractar.Data;
using InfraStractar.Repository.RepositoryModels;
using InfraStractar.RigestarServices;
using SQL_Coding.Sql_Models;

namespace OnlineStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();

            builder.Services.AddDbContext<StoryContext>();
            Rigestar.Rigestarition(builder.Services);

                 // Add Swagger services
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHangfireDashboard("/hangfire");
            app.UseHttpsRedirection();

            using (var scope = app.Services.CreateScope())
            {
                Rigestar.print(scope.ServiceProvider);
            }
            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}