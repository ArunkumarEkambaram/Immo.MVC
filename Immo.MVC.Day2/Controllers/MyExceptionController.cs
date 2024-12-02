using Microsoft.AspNetCore.Mvc;

namespace Immo.MVC.Day2.Controllers
{
    //[TypeFilter(typeof(CustomExceptionFilter))]    
    public class MyExceptionController : Controller
    {      
        public IActionResult Index(int? id)
        {
            if (id == 1)
            {
                throw new FileNotFoundException("Testing Exception Page");
            }
            else if (id == 2)
            {
                return StatusCode(500);
            }
            return View();
        }

        public IActionResult StatusCodeErrorPage(int? code)
        {
            if(code == 404)
            {
                ViewBag.ErrorCode = "404";
                ViewBag.ErrorMessage = "Page Not Found!";
            }
            else if(code == 500)
            {
                ViewBag.ErrorCode = "500";
                ViewBag.ErrorMessage = "Internal Server Error. Please try later";
            }
            else if(code == 400)
            {
                ViewBag.ErrorCode = "400";
                ViewBag.ErrorMessage = "Bad Request!";
            }
            else
            {
                ViewBag.ErrorMessage = "An error while processing your request. Please try again later";
            }
            return View();
        }
    }
}
