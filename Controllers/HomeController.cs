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
//1.���s�U��NuGet�M��G


//1.�bModels��Ƨ����إ�CategoriesProductViewModels.cs(ViewModel)�A�éw�qCategories�MProducts���ݩʡC
//2.�bViewData����JCategories�MProducts����ơA�M��bView���ϥΰj����ܳo�Ǹ�ơC