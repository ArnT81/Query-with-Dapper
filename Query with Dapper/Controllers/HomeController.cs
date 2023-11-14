using Microsoft.AspNetCore.Mvc;
using Query_with_Dapper.DataAccess;
using Query_with_Dapper.Models;
using System.Diagnostics;

namespace Query_with_Dapper.Controllers
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
            List<City> cityList = new CityQuery().GetCities("NLD");
            return View(cityList);
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