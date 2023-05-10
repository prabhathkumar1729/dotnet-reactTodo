using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoAppBL.Repositories;
using TodoAppDAL;
using TodoAppDAL.Models;
using TodoAppDAL.Repositories;

namespace TodoAppBL
{
    public class ConfigBL
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ITodoRepo, TodoRepo>();
            services.AddScoped<IUserRepo, UserRepo>();
            services.AddDbContext<TodoDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("defaultconnection"))
            );
        }
    }
}