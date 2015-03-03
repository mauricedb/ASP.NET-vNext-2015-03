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

            app.UseWelcomePage();
        }
    }
}
