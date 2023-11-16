using Microsoft.AspNetCore.Mvc;
using Query_with_Dapper.DataAccess;
using Query_with_Dapper.Models;

namespace Query_with_Dapper.Controllers
{
    public class CityController : Controller
    {
        // GET: CityController
        public ActionResult Index()
        {
            List<City> cityList = new CityQuery().GetCitiesByCountrycode("SWE");
            return View(cityList);
        }


        // GET: CityController/Details/5
        public ActionResult Details(int id)
        {
            CityDetails city = new CityQuery().GetCityById(id);
            return View(city);
        }



        public ActionResult Test()
        {
            List<CityDetails> cityList = new CityQuery().GetCityByPopulation(100, 10000);
            return View(cityList);
        }


        // GET: CityController/Create
        public ActionResult Create()
        {
            CityDetails city = new CityDetails();
            return View(city);
        }

        // POST: CityController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        public ActionResult Create(CityDetails model)
        {
            try
            {
                new CityQuery().CreateCity(model.Name, model.Population, model.CountryCode, model.District);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CityController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CityController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CityController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CityController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
