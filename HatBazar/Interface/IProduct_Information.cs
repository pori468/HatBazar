using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HatBazar.Models;

namespace HatBazar.Interface
{
    interface IProduct_Information
    {
       List<Product_Information> Index(string option, string search, int? Type);
        ProductModel Details(int id);
        string Addtocart(int? id, string Customerid);
        string Create(ProductModel Product);
        ProductModel GetEdit( int id);
        string PostEdit(ProductModel Product);

        ProductModel GetDelete(int id);
        string PostDelete(int id);
        List<Product_Information> Status(int id);





    }
}
