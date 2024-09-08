using Microsoft.AspNetCore.Mvc;

namespace Demo01.controllers
{
    public class MoviesController : Controller
    {
        public void GetMovie()
        {

        }

        public IActionResult Index()
        {
            ContentResult result = new ContentResult();
            return Content("Hello From Index", "text/html");
        }



    }
}
