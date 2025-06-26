using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NorthWind.Models;

namespace NorthWind.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}


///////////////////////////////////
//1.重新下載NuGet套件：


//1.在Models資料夾中建立CategoriesProductViewModels.cs(ViewModel)，並定義Categories和Products的屬性。
//2.在ViewData中放入Categories和Products的資料，然後在View中使用迴圈顯示這些資料。