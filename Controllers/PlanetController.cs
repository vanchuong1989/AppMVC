using AppMVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace AppMVC.Controllers
{
    public class PlanetController : Controller
    {
        private readonly PlanetService _planetService;
        private readonly ILogger<PlanetController> _logger;

        public PlanetController(PlanetService planetSerice, ILogger<PlanetController> logger)
        {
            _planetService = planetSerice;
            _logger = logger;
        }

        [Route("danhsachhanhtinh")]
        public IActionResult Index()
        {
            return View();
        }

        [BindProperty(SupportsGet =true, Name = "action")]
        public string Name { get; set; }

        public IActionResult Mercury()
        {
            var planet = _planetService.Where(p=>p.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }
        public IActionResult Venus()
        {
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }
        public IActionResult Earth()
        {
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }

        public IActionResult PlanetInfor(int id)
        {
            var planet = _planetService.Where(p => p.Id == id).FirstOrDefault();
            return View("Detail", planet);
        }
    }
}
