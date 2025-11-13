using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrabajandoConRazor.ViewModels
{
    public class ProductViewModel
    {
        public string[] AllProducts { get; set; }
        public string[] ProductsAtEvenPosition { get; set; }

    }
}