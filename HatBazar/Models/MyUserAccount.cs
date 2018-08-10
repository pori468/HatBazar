using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace HatBazar.Models
{
    public class MyUserAccount
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        [Display(Name = "Full Name")]
        public string Name { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address is Required")]
        public string Address { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number is Required")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Type")]
        [Required(ErrorMessage = "Type is Required")]
        public string Type { get; set; }

        [Display(Name = "User Name")]
        [Required(ErrorMessage = "User Name  is Required")]
        public string UserName { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Please Confirm Your Password")]
        [DataType(DataType.Password)]
        public string Confirm { get; set; }








    }
}