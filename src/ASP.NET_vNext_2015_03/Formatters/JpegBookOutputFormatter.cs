using System.IO;
using System.Text;
using System.Threading.Tasks;
using ASP.NET_vNext_2015_03.Models;
using Microsoft.AspNet.Mvc;
using Microsoft.Net.Http.Headers;

namespace ASP.NET_vNext_2015_03.Formatters
{
    public class JpegBookOutputFormatter : OutputFormatter
    {
        private readonly string _folder;

        public JpegBookOutputFormatter(string folder)
        {
            _folder = folder;

            SupportedEncodings.Add(Encoding.GetEncoding("utf-8"));
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("image/jpeg"));
        }

        public override bool CanWriteResult(OutputFormatterContext context, MediaTypeHeaderValue contentType)
        {
            return context.DeclaredType == typeof (Book) || context.Object is Book;
        }

        public override Task WriteResponseBodyAsync(OutputFormatterContext context)
        {
            var response = context.ActionContext.HttpContext.Response;

            var book = context.Object as Book;
            if (book != null)
            {
                var path = Path.Combine(_folder, book.ImageName);
                var buffer = File.ReadAllBytes(path);

                response.Body.Write(buffer, 0, buffer.Length);
            }

            return Task.FromResult(true);
        }
    }
}