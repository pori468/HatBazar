using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HatBazar.Models
{
    public class JobApplication
    {
        

            [Key]
            public string Application_id { get; set; }

            
            [Display(Name  = "First Name")]
            [Required(ErrorMessage = "First Name is Required")]
            public string First_name { get; set; }

            [Display(Name = "Last Name")]
            [Required(ErrorMessage = "Last Name is Required")]
            public string Last_name { get; set; }

            [Display(Name = "Address")]
            [Required(ErrorMessage = "Address is Required")]
            public string Address { get; set; }

            [Display(Name = "Phone Number")]
            [Required(ErrorMessage = "Phone Number is Required")]
            public int Phone { get; set; }

            [Required(ErrorMessage = "Email is Required")]
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }

            [Display(Name = "Gender")]
            [Required(ErrorMessage = "Gender is Required")]
            public string Gender { get; set; }

            [Display(Name = "Date Of Birth")]
            [Required(ErrorMessage = "date is Required")]
            public string Date { get; set; }

            [Display(Name = "Month")]
            [Required(ErrorMessage = "Month is Required")]
            public string Month { get; set; }

            [Display(Name = "Year")]
            [Required(ErrorMessage = "Year is Required")]
            public string BirthYear { get; set; }

            [Display(Name = "Status")]
            [Required(ErrorMessage = "Status is Required")]
            public string Marrage_status { get; set; }

            [Display(Name = "Qualification")]
            [Required(ErrorMessage = "Qualification is Required")]
            public string Last_degree { get; set; }

            [Display(Name = "Year Passed")]
            [Required(ErrorMessage = "Year is Required")]
            public int Year { get; set; }

            [Display(Name = "Subject")]
            [Required(ErrorMessage = "Subject is Required")]
            public string Subject { get; set; }

            [Display(Name = "Post")]
            [Required(ErrorMessage = "Post is Required")]
            public string Post { get; set; }

            [Display(Name = "About Yourself")]
            [Required(ErrorMessage = "Write Something About Yourself.")]
            public string About { get; set; }

      


    }
}
