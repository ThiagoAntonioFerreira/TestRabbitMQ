using Microsoft.AspNetCore.Mvc;

namespace TestRabbitMQ.Controllers
{
    public class ConsumerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
