using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HatBazar.Models
{
    public class Report_Model
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Please Enter Valid Date ")]
        [Display(Name = "Starting Date (DD/MM/YY)")]
        [DataType(DataType.DateTime)]
        public string StartDate { get; set; }

        [Display(Name = "Ending Date (DD/MM/YY)")]
        [Required(ErrorMessage = "Please Enter Valid date")]
        [DataType(DataType.DateTime)]
        public string EndDate { get; set; }

     List <Order_For_Shop> order { get; set; }



    }
}