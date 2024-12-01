using Microsoft.AspNetCore.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace Immo.MVC.Day2.GlobalExceptions
{
    public static class CustomExceptionHandler
    {
        public static void CustomError(IApplicationBuilder app)
        {
            app.Run(async context =>
             {
                 context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                 context.Response.ContentType = Text.Html;

                 await context.Response.WriteAsync("<html><body>\r\n");
                 await context.Response.WriteAsync("<div class='display-2'>Error!!!</div>\n\n");

                 var exceptionFeatures = context.Features.Get<IExceptionHandlerFeature>();

                 if (exceptionFeatures?.Error is FileNotFoundException)
                 {
                     await context.Response.WriteAsync("<div class='display-3'>File Not Found!</div>\n\n");
                 }

                 await context.Response.WriteAsync("<a href='/MyException'>Go Back</a>\n");

                 await context.Response.WriteAsync("</body></html>\n");
                 await context.Response.WriteAsync(new string(' ', 512));
             });
        }   
    }
}
