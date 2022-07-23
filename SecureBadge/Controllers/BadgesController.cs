using Microsoft.AspNetCore.Mvc;

namespace SecureBadge.Controllers
{
    public class BadgesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
