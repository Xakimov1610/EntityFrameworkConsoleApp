using efconsole.Data;
using efconsole.services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace efconsole
{
    public class Startup
    {
        public IConfiguration Configuration { get; private set; }
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        } 

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ConsoleDbContext>(
                options =>
                {
                    if(Configuration.GetValue<bool>("UseInMemoryDatabase"))
                    {
                        options.UseSqlite(Configuration.GetConnectionString("SqliteConnection"));
                    }
                    else
                    {
                        options.UseSqlServer(Configuration.GetConnectionString("SqlServerConnection"));
                    }
                }, ServiceLifetime.Singleton);

            services.AddHostedService<ConsoleService>();
            services.AddTransient<IStorageTeacherService, DbStorageTeacherService>();
            services.AddTransient<DbStorageStudentService>();
            services.AddTransient<InternalStorageTeacherService>();
            services.AddTransient<InternalStorageStudentService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
        }
    }
}