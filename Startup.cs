using Microsoft.EntityFrameworkCore;
using MouseYazilim.Data;

namespace MouseYazilim
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("Error: DefaultConnection string is missing or empty in the configuration.");
            } else
            {
                services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlite(connectionString)
                );
            }
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
             if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Login/Error");
                app.UseHsts();
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=User}/{action=Index}/{id?}");
            });
        }
    }
}