using Microsoft.AspNetCore.Mvc;

namespace TestRabbitMQ.Controllers
{
    public class SenderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
