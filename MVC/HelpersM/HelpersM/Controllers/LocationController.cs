using HelpersM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;

namespace HelpersM.Controllers
{
    public class LocationController : Controller
    {
        private static List<Country> countries = new List<Country>
        {
            new Country{Id=1,Name="USA"},
            new Country{Id=2,Name="Canada" }
        };
        private static List<City> cities = new List<City>
        {
            new City{Id=1,Name="NewYork",CountryId=1},
            new City{Id=2,Name="Los Angeles",CountryId=1},
            new City{Id=3,Name="Toronto",CountryId=2},
            new City{Id=4,Name="Vancouver",CountryId=2},
        };
        // GET: Location
        public ActionResult Index()
        {
            var model = new LocationViewModel
            {
                Countries = countries.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }),
                Cities= new List<SelectListItem>(),
                AllCities= cities.Select(c=>new City
                {
                    Id= c.Id,
                    Name= c.Name,
                    CountryId= c.CountryId
                })
            };

            return View(model);
        }
    }
}