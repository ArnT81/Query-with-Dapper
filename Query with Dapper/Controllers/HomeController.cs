using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Query_with_Dapper.DataAccess;
using Query_with_Dapper.Models;
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Runtime.Intrinsics.X86;
using Microsoft.Extensions.Hosting;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using System.Diagnostics.Metrics;
using Humanizer;

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
            ViewBag.Assignments = Assignments;
            return View();
        }


        public List<CityDetails> Basic()
        {
            //Present a list of strongly typed city data for all cities in a span between two
            //population numbers.Use a view file(cshtml) for the presentation and use a
            //table for the data.

            List<CityDetails> cityList = new CityQuery().GetCityByPopulation(500, 1000);
            return cityList;
        }


        public List<CityDetails> OptionalAssignment1()
        {
            //Limit the number of posts read.
            List<CityDetails> cityList = new CityQuery().GetCityWithLimitation(10);
            return cityList;
        }


        //TODO GET ALL DATA 
        public List<City> OptionalAssignment2()
        {
            //Read all cities by country code.
            List<City> cityList = new CityQuery().GetCitiesByCountrycode("SWE");
            return cityList;
        }






        //NOT DONE YET

        public List<CityDetails> OptionalAssignment3()
        {
            //Read all European countries ordered by life expectancy, high to low.
            List<CityDetails> cityList = new CityQuery().GetCitiesInEuropeByLifeExpectancy();
            return cityList;
        }


        public List<CityDetails> OptionalAssignment4()
        {
            //Read all cities in a country.
            List<CityDetails> cityList = new CityQuery().GetCityByPopulation(500, 1000);
            return cityList;
        }


        public List<CityDetails> OptionalAssignment5()
        {
            //Read all cities in a continent with a life expectancy above a certain age.
            List<CityDetails> cityList = new CityQuery().GetCityByPopulation(500, 1000);
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