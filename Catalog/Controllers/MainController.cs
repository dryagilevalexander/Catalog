using Catalog.Models;
using Catalog.Services;
using Core;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers
{
    [ApiController]
    [Route("/")]
    public class MainController : Controller
    {
        CoreContext db;
        IOperationsService _operationsService;
        public MainController(CoreContext coreContext, IOperationsService operationsService)
        {
            db = coreContext;
            _operationsService = operationsService;
        }
        [Route("/cities")]
        [HttpGet]
        public IActionResult GetCities ()
        {
            IQueryable<CityModel>? cities = _operationsService.GetCities();
            if (cities != null && cities.Any())
            {
                return Json(cities);
            }
            else
            {
                return NotFound();
            }
        }


        [Route("/cities/{city_id}/streets")]
        [HttpGet]
        public IActionResult GetStreetsByCityId(string city_id)
        {
            int n;
            bool isNumeric = int.TryParse(city_id, out n);

            if (isNumeric == true)
            {
                IQueryable<StreetModel>? streets = _operationsService.GetStreetsByCityId(n);
                if (streets != null && streets.Any())
                {
                    return Json(streets);
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return NotFound();
            }
        }


        [Route("/cities/{city_id}/houses")]
        [HttpGet]
        public IActionResult GetHousesByCityId(string city_id)
        {
            int n;
            bool isNumeric = int.TryParse(city_id, out n);

            if (isNumeric == true)
            {
                IQueryable<HouseModel>? houses = _operationsService.GetHousesByCityId(n);
                if(houses != null && houses.Any())
                { 
                    return Json(houses);
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return NotFound();
            }
        }

        [Route("/streets/{street_id}/houses")]
        [HttpGet]
        public IActionResult GetHousesByStreetId(string street_id)
        {
            int n;

            bool isNumeric = int.TryParse(street_id, out n);

            if (isNumeric == true)
            {
                IQueryable<HouseModel>? houses = _operationsService.GetHousesByStreetId(n);
                if (houses != null && houses.Any())
                {
                    return Json(houses);
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return NotFound();
            }
        }
    }
}
