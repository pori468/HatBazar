using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HatBazar.Models
{
    public class Complain
    {


            [Key]
            public int ID { get; set; }

            [Required(ErrorMessage = "Please Enter Valid User Name ")]
            [Display(Name = "User Name")]
            public string User_Name { get; set; }

            [Display(Name = "Massage")]
            [Required(ErrorMessage = "EMPTY !!!!!")]
            public string Message { get; set; }

            

        }
}