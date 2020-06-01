using Microsoft.AspNetCore.Mvc;
using KissLog;
namespace AspNetCoreIdentity.Controllers
{
    public class TesteController : Controller
    {
        private readonly ILogger _logger;

        public TesteController(ILogger logger )
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.Info("Passei na Index da controller teste");

            
            return View();
        }
    }
}