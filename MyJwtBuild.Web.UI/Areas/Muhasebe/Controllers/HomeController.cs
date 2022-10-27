using Microsoft.AspNetCore.Mvc;

namespace MyJwtBuild.Web.UI.Areas.Muhasebe.Controllers
{
    [Area("Muhasebe")]
    public class HomeController : Controller
    {
      
        public IActionResult MuhAnaEkran()
        {
            return View();
        }
    }
}
