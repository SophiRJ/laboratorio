using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelpersM.Models
{
    public class LocationViewModel
    {
        public IEnumerable<SelectListItem> Countries { get; set; }
        public int SelectedCountryId { get; set; }
        public IEnumerable<SelectListItem> Cities { get; set; }
        public int SelectedCityId { get; set; }
        public IEnumerable<City> AllCities { get; set; }
    }
}