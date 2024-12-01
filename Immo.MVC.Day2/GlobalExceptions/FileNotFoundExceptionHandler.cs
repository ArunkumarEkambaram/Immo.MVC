using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;
using static System.Net.Mime.MediaTypeNames;

namespace Immo.MVC.Day2.GlobalExceptions
{
    public static class FileNotFoundExceptionHandler
    {
        public static void CustomError(IApplicationBuilder app)
        {
            app.Run(async context =>
             {
                 context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                 context.Response.ContentType = Text.Html;

                 await context.Response.WriteAsync("<html><body>\r\n");
                 await context.Response.WriteAsync("<h3>Error!!!</h3>\n\n");

                 var exceptionFeatures = context.Features.Get<IExceptionHandlerFeature>();

                 if (exceptionFeatures?.Error is FileNotFoundException)
                 {
                     await context.Response.WriteAsync("<p>File Not Found!</p>\n\n");
                 }

                 await context.Response.WriteAsync("<a href='/MyException/Index'>Home</a>\n");

                 await context.Response.WriteAsync("</body></html>\n");
                 await context.Response.WriteAsync(new string(' ', 512));
             });
        }   
    }
}
