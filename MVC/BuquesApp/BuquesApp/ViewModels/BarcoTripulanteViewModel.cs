using BuquesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuquesApp.ViewModels
{
    public class BarcoTripulanteViewModel
    {
        public IEnumerable<SelectListItem> Barcos { get; set; }
        public int SelectedBarcoId { get; set; }
        public IEnumerable<SelectListItem> Tripulantes { get; set; }
        public int SelectedTripulantesId { get; set; }
        public IEnumerable<Tripulante> AllTripulantes { get; set; }

    }
}