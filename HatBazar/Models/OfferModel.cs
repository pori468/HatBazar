using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace HatBazar.Models
{
    public class OfferModel
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = " Campaign Name Required ")]
        [Display(Name = "Campaign  Name")]
        public string Campaign_Name { get; set; }

        [Display(Name = "Start")]
        public string startdate { get; set; }
        public string startmonth { get; set; }
        public string startyear { get; set; }

        [Display(Name = "End")]
        public string Enddate { get; set; }
        public string Endmonth { get; set; }
        public string Endyear { get; set; }

        //[Display(Name = "start date")]
        //[Required(ErrorMessage = "Required !!!!!")]
        //public DateTime StartDate { get; set; }

        //[Display(Name = "end date")]
        //[Required(ErrorMessage = "Required !!!!!")]
        //public DateTime EndDate { get; set; }

        [Required(ErrorMessage = " A Unique Package Name Required ")]
        [Display(Name = "Package  Name")]
        public string Package_Name { get; set; }

        [Display(Name = "Package Price :")]
        [Required(ErrorMessage = "Is It Free !!!!!")]
        public int Price { get; set; }





    }
}