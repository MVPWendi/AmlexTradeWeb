using AmlexTradeWeb.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmlexTradeWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })

        .AddCookie(options =>
        {
            options.LoginPath = "/login";
            options.LogoutPath = "/signout";
        })

        .AddOpenId("StackExchange", "StackExchange", options =>
        {
            options.Authority = new Uri("https://openid.stackexchange.com/");
            options.CallbackPath = "/signin-stackexchange";
        }).AddSteam();
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ForumDB>(options =>
                options.UseSqlServer(connection));
            services.AddControllersWithViews();

            
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();

            app.UseRouting();
           
            app.UseAuthentication();
            app.UseAuthorization();
            //app.UseMiddleware<AuthenticationMiddleware>();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action}");
                endpoints.MapControllerRoute(name: "default", pattern: "{controller=Wiki}/{action=Plugin}/{Name}");
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
