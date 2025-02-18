using System.Threading.Tasks;
using Auth.Authentication_Models;
using Hangfire;
using InfraStractar.Data;
using InfraStractar.Repository.RepositoryModels;
using Microsoft.Extensions.DependencyInjection;
using SQL_Coding.Sql_Models;

namespace InfraStractar.RigestarServices
{
    public class Rigestar
    {
     
        private static readonly SQLinject inject=new SQLinject();

       


        public static void Rigestarition( IServiceCollection services)
        {
            services.AddSingleton<IRecurringJobManager, RecurringJobManager>();
            services.AddScoped<ISQLinject, SQLinject>();
            services.AddHangfire(config => config.UseSqlServerStorage(StoryContext.database));
            services.AddScoped<ApplicationRepository>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            //Task_function();
            services.AddHangfireServer();
            services.AddScoped<UserRepository>();
            services.AddScoped<UserApplicationRepository>();
            services.AddScoped<TokenServices>();
            services.AddHangfireServer();
           
        }
        public static void print(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var sqlInject = scope.ServiceProvider.GetRequiredService<ISQLinject>();
                sqlInject.Task_function(StoryContext.database);
            }
        }
    }
}
