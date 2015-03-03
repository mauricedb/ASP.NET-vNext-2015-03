using System;
using System.Net;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.DependencyInjection;

namespace ASP.NET_vNext_2015_03
{
    public class Startup
    {


        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app)
        {
            //app.Use(async (ctx, next) =>
            //{
            //    try
            //    {
            //        await next();

            //    }
            //    catch (Exception ex)
            //    {
            //        ctx.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            //        await ctx.Response.WriteAsync("Oops: " + ex.Message);
            //    }
            //});

            app.UseErrorPage();

            //app.Use((ctx, next) => { throw new DivideByZeroException(); });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" });

                // Uncomment the following line to add a route for porting Web API 2 controllers.
                // routes.MapWebApiRoute("DefaultApi", "api/{controller}/{id?}");
            });

            app.UseWelcomePage();
        }
    }
}
