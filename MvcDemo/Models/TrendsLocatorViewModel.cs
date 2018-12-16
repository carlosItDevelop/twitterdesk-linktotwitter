using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcDemo.Models
{
    public class TrendsLocatorViewModel
    {
        [Display(Name = "Código")]
        public int WoeID { get; set; }

        [Display(Name = "Nome da Locator")]
        public string Name { get; set; }

        [Display(Name = "País")]
        public string Country { get; set; }

        [Display(Name = "Cód. País")]
        public string CountryCode { get; set; }

        [Display(Name = "Id Parent")]
        public string ParentID { get; set; }

        [Display(Name = "Tipo da Praça")]
        public string PlaceTypeName { get; set; }

        [Display(Name = "Cód. Tipo da Praça")]
        public int PlaceTypeNameCode { get; set; }
        public string Url { get; set; }

    }
}