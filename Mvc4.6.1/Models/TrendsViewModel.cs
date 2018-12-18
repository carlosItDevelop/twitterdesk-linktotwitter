using System;
using System.ComponentModel.DataAnnotations;

namespace MvcDemo.Models
{

    public class Location  /// O mesmo que TrendsLocatorViewModel => Substituir depois!!!
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

    public class TrendsViewModel
    {
        public string Name { get; set; }
        //public int Type { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime AsOf { get; set; }
        //public string Query { get; set; }
        //public string SearchUrl { get; set; }
        //public double Latitude { get; set; }
        //public double Longitude { get; set; }
        //public int WoeID { get; set; }
        public bool Exclude { get; set; }
        public object Events { get; set; }
        //public object PromotedContent { get; set; }
        //public List<Location> Locations { get; set; }
        public int TweetVolume { get; set; }
    }


}