using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using HatBazar.Interface;
using HatBazar.Models;



using System.Web.Mvc;

using System.Data;
using System.Net;



namespace HatBazar.Methods
{
    public class MyAccountClass : IMyAccount
    {
        Hat_Bazar_databaseEntities Data = new Hat_Bazar_databaseEntities();
       

        //public string Login(MyUserAccount user)
        //{
        //    //using (Hat_Bazar_databaseEntities Data = new Hat_Bazar_databaseEntities())
        //    {
        //        try
        //        {
        //            var usr = Data.Customer_Information.Single(u => u.User_id == user.UserName && u.Password == user.Password);
        //            if (usr != null)
        //            {
        //                string Role;
        //                Session["Customer_id"] = usr.Customer_id.ToString();
        //                Session["UserName"] = usr.User_id.ToString();

        //                int i = Data.Customer_Order.Count(x => x.Purches_id == usr.Customer_id.ToString() && x.Order_Status == 1);
        //                Session["Cart"] = i.ToString();

        //                if (usr.User_id.ToString() == "ADMIN1" || usr.User_id.ToString() == "ADMIN2")
        //                { Role = "Admin_Page"; }
        //                else
        //                { Role = "Home"; }



        //            }
        //            else
        //            {
        //                ModelState.AddModelError("", "User Name Or Password is wrong");
        //            }
        //        }

        //        catch
        //        {
        //            ModelState.AddModelError("", "User Name Or Password is wrong");
        //        }
        //    }
        //}

     //   public Customer_Information GetMyPage(int CustomerId)
     //   {
           
     //       Customer_Information c = Data.Customer_Information.Single(x => x.Customer_id == CustomerId);
     //       return c;
     //   }

     //public string PostMyPage(Customer_Information MyInfo)
     //   {
     //       if (MyInfo != null)
     //       {
     //           try { 

     //           Customer_Information a = Data.Customer_Information.Single(x => x.Customer_id == MyInfo.Customer_id);

     //           a.Name = MyInfo.Name;
     //           a.Address = MyInfo.Address;
     //           a.Phone = MyInfo.Phone;
     //           a.Email = MyInfo.Email;
     //           a.Type = MyInfo.Type;
     //           a.User_id = MyInfo.User_id;
     //           a.Password = MyInfo.Password;

     //           Data.Entry(a).State = EntityState.Modified;


     //           return "Informations are Updated Successfully.";
     //           }

     //           catch

     //           {
     //               return "Informations are  Not Updated. Please Try Later";
     //           }
     //       }

     //       else
     //       {

     //           return "Informations are  Not Updated. Please Try Later";
     //       }
     //   }
    }
}