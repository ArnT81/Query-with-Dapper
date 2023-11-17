using Microsoft.AspNetCore.Mvc;
using Query_with_Dapper.DataAccess;
using Query_with_Dapper.Models;
using System.Collections.Generic;
using System.Diagnostics;

namespace Query_with_Dapper.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private List<Assignment> Assignments;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            Assignments = new List<Assignment>
            {
                new Assignment { Id = 0, Name = "--Select Task--" },
                new Assignment { Id = 1, Name = "Basic" },
                new Assignment { Id = 2, Name = "Optional 1" },
                new Assignment { Id = 3, Name = "Optional 2" },
                new Assignment { Id = 4, Name = "Optional 3" },
                new Assignment { Id = 5, Name = "Optional 4" },
                new Assignment { Id = 6, Name = "Optional 5" }
            };
        }

        public IActionResult Index()
        {
            List<int> between = new List<int>() { 1, 2 };
            ViewBag.Between = between;

            return View(Assignments);
        }


        public List<CityDetails> Basic(int min, int max)
        {
            //Present a list of strongly typed city data for all cities in a span between two
            //population numbers.Use a view file(cshtml) for the presentation and use a
            //table for the data.

            List<CityDetails> cityList = new CityQuery().GetCityByPopulation(min, max);
            return cityList;
        }


        public List<CityDetails> OptionalAssignment1(int limit)
        {
            Console.WriteLine(limit);
            //Limit the number of posts read.
            List<CityDetails> cityList = new CityQuery().GetCityWithLimitation(limit);
            return cityList;
        }


        public List<City> OptionalAssignment2(string countrycode)
        {
            //Read all cities by country code.
            List<City> cityList = new CityQuery().GetCitiesByCountrycode(countrycode);
            return cityList;
        }


        public List<CityDetails> OptionalAssignment3()
        {
            //Read all European countries ordered by life expectancy, high to low.
            List<CityDetails> cityList = new CityQuery().GetCitiesInEuropeByLifeExpectancy();
            return cityList;
        }


        public List<City> OptionalAssignment4(string countryName)
        {
            //Read all cities in a country.
            List<City> cityList = new CityQuery().GetCityByCountryName(countryName);
            return cityList;
        }


        public List<CityDetails> OptionalAssignment5(string continent, int age)
        {
            //Read all cities in a continent with a life expectancy above a certain age.
            List<CityDetails> cityList = new CityQuery().GetCityByContinentAndLifeExpectancy(continent, age);
            return cityList;
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