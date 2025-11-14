using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuquesApp.Models
{
    public class LocationViewModel
    {
        public IEnumerable<SelectListItem> Barcos { get; set; }
        public int SelectedBarcoId { get; set; }
        public IEnumerable<SelectListItem> Tripulantes { get; set; }
        public int SelectedTripulanteId { get; set; }
        public IEnumerable<Tripulante> AllTripulantes { get; set; }
    }
}