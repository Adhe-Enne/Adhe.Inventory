using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Inventory.Data.IoC
{
    public static class Startup
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Add services to the container.
          // services.AddDbContext<ApplicationDbContext>(options =>
          //     options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
          // services.AddIdentity<IdentityUser, IdentityRole>()
          //     .AddEntityFrameworkStores<ApplicationDbContext>()
          //     .AddDefaultTokenProviders();
            // Add other services as needed
            // e.g., services.AddScoped<IYourService, YourService>();
            
            var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddIdentityCore<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
        }
    
    }
}
