using Microsoft.AspNetCore.Mvc.Filters;

namespace Immo.MVC.Day2.GlobalExceptions
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var controller = context.RouteData.Values["controller"];
            var action = context.RouteData.Values["action"];

            string errMsg = $"An error occurred on DateTime :{DateTime.Now}\n\nController Name: {controller}\tAction Name: {action}\nException Message: {context.Exception.Message}\n";
            File.AppendAllText(Path.Combine(Directory.GetCurrentDirectory(), "ErrorLogs", "ErrorLog.txt"), errMsg);
        }
    }
}
