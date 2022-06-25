using AppMVC.ExtendMethods;
using AppMVC.Models;
using AppMVC.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AppMVC
{
    public class Startup
    {
        public static string ContetnRootPath { get; set; }
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            ContetnRootPath = env.ContentRootPath;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<AppDbContext>(options => {
                string connectString = Configuration.GetConnectionString("AppMvc");
                options.UseSqlServer(connectString);
            });


            services.AddControllersWithViews();
            services.AddRazorPages();

            //setup another View
            //{0}->Action
            //{1}->Controller
            //{2}->Area
            services.Configure<RazorViewEngineOptions>(options => {
                options.ViewLocationFormats.Add("/MyView/{1}/{0}" + RazorViewEngine.ViewExtension);
            });

            services.AddSingleton(typeof(ProductService), typeof(ProductService));
            services.AddSingleton<PlanetService>();
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
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.AddStatusCodePage(); // Method Extention StatusCodePage

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: "{controller=Home}/{action=Index}/{id?}");

                ////tạo những điểm Endpoint đến các trang Razor
                //endpoints.MapRazorPages();

                endpoints.MapGet("/sayhi", async (context) => {
                    await context.Response.WriteAsync($"Hello ASP.NET {DateTime.Now}");
                });


                endpoints.MapControllerRoute(
                        name: "first",
                        pattern: "{url}/{id?}",
                        defaults: new
                        {
                            controller = "First",
                            action = "ViewProduct"
                        },

                        constraints: new
                        {
                            url = new StringRouteConstraint("xemsanpham"),
                            id = new RangeRouteConstraint(2, 4)
                        }

                    );

                endpoints.MapAreaControllerRoute(
                        name: "product",
                        pattern:"/{controller}/{action=Index}/{id?}",
                        areaName: "ProductManager"
                    );

                endpoints.MapControllerRoute(
                        name:"default",
                        pattern:"/{controller=Home}/{action=Index}/{id?}"
                        
                    );

                endpoints.MapRazorPages();
            });
        }
    }
}
