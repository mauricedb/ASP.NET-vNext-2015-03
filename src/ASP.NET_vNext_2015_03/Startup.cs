using System;
using System.IO;
using System.Linq;
using System.Net;
using ASP.NET_vNext_2015_03.Formatters;
using ASP.NET_vNext_2015_03.Models;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json.Serialization;

namespace ASP.NET_vNext_2015_03
{
    public class Startup
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public Startup(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton<IBooksRepository, BooksRepository>();

            services.Configure<MvcOptions>(options =>
            {
                var jsonOutputFormatter =
                    (JsonOutputFormatter)options.OutputFormatters.First(f => f.Instance is JsonOutputFormatter).Instance;
                jsonOutputFormatter.SerializerSettings.ContractResolver =
                    new CamelCasePropertyNamesContractResolver();

                var jpegMediaTypeOutputFormatter =
                     new JpegBookOutputFormatter(Path.Combine(_hostingEnvironment.WebRoot, @"..\Images"));
                options.OutputFormatters.Insert(0, jpegMediaTypeOutputFormatter);
            });
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

            //app.UseWelcomePage();
        }
    }
}
