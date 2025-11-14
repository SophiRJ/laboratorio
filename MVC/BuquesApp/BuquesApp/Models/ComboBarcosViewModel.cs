using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuquesApp.Models
{
    public class ComboBarcosViewModel
    {
        public List<Barco> Barcos { get; set; }
        public int SelectedBarco { get; set; }
    }
}