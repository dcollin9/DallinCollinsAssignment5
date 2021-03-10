using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DallinCollinsAssignment5.Models;
using Microsoft.EntityFrameworkCore;

namespace DallinCollinsAssignment5
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<Assignment5DBContext>(options =>
           {
               options.UseSqlite(Configuration["ConnectionStrings:Assignment5Connection"]);
           });

            services.AddScoped<Assign5Repository, EFAssign5Repository>();

            services.AddRazorPages();

            services.AddDistributedMemoryCache();

            services.AddSession();
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

            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {



                //if the user passes a category and a page
                //gets the category first, then the page
                endpoints.MapControllerRoute("catpage",
                    "{category}/{page:int}",
                    new { Controller = "Home", action = "Index" }
                    );

                //if the user just gives you a page number
                endpoints.MapControllerRoute("page",
                    "{page:int}",
                   new { Controller = "Home", action = "Index" }
                    );

                //should go third
                //user gives us only a category
                endpoints.MapControllerRoute("category",
                    "{category}",
                    new { Controller = "Home", action = "Index", page = 1 }
                    );


                endpoints.MapControllerRoute(
                   "pagination",
                   "P{page}",
                   new { Controller = "Home", action = "Index" });

                endpoints.MapDefaultControllerRoute();

                endpoints.MapRazorPages();

            });

            //don't need this after initial run
          SeedData.EnsurePopulated(app);
        }
    }
}
