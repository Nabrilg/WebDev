using System;
using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using WebDev.Application.Config;
using WebDev.Application.Controllers;

namespace WebDev.Application
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
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.Configure<ApiConfiguration>(Configuration.GetSection("ApiConfiguration"));

            // Enable Session Handler
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(1);//You can set Time
            });
            services.AddMvc();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            ServicePointManager.ServerCertificateValidationCallback +=
            (sender, certificate, chain, sslPolicyErrors) => true;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            GlobalDataInjectorAttribute.Configure(app.ApplicationServices
                     .GetRequiredService<IHttpContextAccessor>());

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseCookiePolicy();
            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                // Users
                endpoints.MapControllerRoute(
                  name: "Users",
                  pattern: "{controller=Users}/{action=Index}/{id?}");
                // Concepts
                endpoints.MapControllerRoute(
                  name: "Concepts",
                  pattern: "{controller=Concepts}/{action=Index}/{id?}");
            });
        }
    }
}
