using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo01
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
                endpoints.MapGet("/Home", async context =>
                {
                    await context.Response.WriteAsync("Hello You Are In HomePage!");
                });
                endpoints.MapGet("/books/{ID}/{Author}", async context =>
                {
                    int id = Convert.ToInt32(context.Request.RouteValues["ID"]);
                    String Author = context.Request.RouteValues["Author"].ToString();
                    await context.Response.WriteAsync($"Hello You Are In BookId = {id} and Author is {Author}");
                });
                endpoints.MapControllerRoute(
                    name: "Default",
                    pattern: "{Controller}/{action=Index}/{id?}");
            });
            app.Run(async (HttpContext) =>
            { await HttpContext.Response.WriteAsync("Your Reauest Is Not Foud"); });
        }
    }
}
