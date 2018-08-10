using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HatBazar.Models;
using System.ComponentModel.DataAnnotations;

namespace HatBazar.Models
{
    public class ProductModel
    {
        [Key]
        public int product_id { get; set; }

        [Required(ErrorMessage = "Product Name is Required")]
        [Display(Name = "Product Name")]
        public string Product_name { get; set; }

        [Required(ErrorMessage = "Product Unit is Required")]
        [Display(Name = "Product Unit")]
        public string Unit { get; set; }

        [Required(ErrorMessage = "Price is Required")]
        [Display(Name = "Price( Per Unit ) ")]
        public int price_per_unit { get; set; }

        
        [Display(Name = "Product Tag")]
        public string tag { get; set; }

        
        public string SpecialOffer { get; set; }

        [Required(ErrorMessage = "No Image is selected")]
        [Display(Name = "Upload Image")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Product Stock")]
        public string stock { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Category ID")]
        public int catagory { get; set; }

       
    }
}