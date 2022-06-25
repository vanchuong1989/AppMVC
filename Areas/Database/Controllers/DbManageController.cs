using AppMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace AppMVC.Areas.Database.Controllers
{
    [Area("Database")]
    [Route("/database-manage/[action]")]
    public class DbManageController : Controller
    {
        private readonly ILogger<DbManageController> _logger;
        private readonly AppDbContext _dbContext;


        public DbManageController(ILogger<DbManageController> logger, AppDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;

        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult DeleteDb()
        {
            _logger.LogInformation("You press Delete button - GET");
            return View();
        }

        [TempData]
        public string StatusMessage { get; set; }

        [HttpPost]
        public async Task<IActionResult> DeleteDbAsync()
        {
            var success = await _dbContext.Database.EnsureDeletedAsync();

            StatusMessage = success ? "Xóa DB thành công" : "Xóa Db Thất bại";

            _logger.LogInformation("You press Delete button - POST");
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Migrate()
        {
             await _dbContext.Database.MigrateAsync();
            StatusMessage = "Cập nhật Database thành công";

            _logger.LogInformation("You press Update DB - POST");

            return RedirectToAction(nameof(Index));
        }
    }
}
