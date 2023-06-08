using Microsoft.AspNetCore.Mvc;

namespace SampleApplication2.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
