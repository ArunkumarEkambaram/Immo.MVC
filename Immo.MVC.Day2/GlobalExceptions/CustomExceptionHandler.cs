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
                 await context.Response.WriteAsync("<h2>-----Error Page------</h2>\n\n</br>");

                 var exceptionFeatures = context.Features.Get<IExceptionHandlerFeature>();

                 if (exceptionFeatures?.Error is FileNotFoundException)
                 {
                     await context.Response.WriteAsync("<h3>File Not Found!</h3>\n\n</br>");
                 }

                 await context.Response.WriteAsync("<a href='/MyException'>Go Back</a>\n");

                 await context.Response.WriteAsync("</body></html>\n");
             });
        }   
    }
}
