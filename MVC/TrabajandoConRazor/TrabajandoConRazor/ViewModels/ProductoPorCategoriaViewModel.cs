using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Configuration;

namespace TrabajandoConRazor.ViewModels
{
    public class ProductoPorCategoriaViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string FormattedPrice { get; set; }
    }
}