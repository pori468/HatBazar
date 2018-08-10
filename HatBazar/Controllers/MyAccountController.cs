using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HatBazar.Models;
using System.Data;
using System.Net;
using HatBazar.Interface;
using HatBazar.Methods;



namespace HatBazar.Controllers
{
    public class MyAccountController : Controller
    {
        
        private readonly IMyAccount Account;
        public MyAccountController()
        {
            Account = new MyAccountClass();
           
        }
        // ei line ta lage !!!
        Hat_Bazar_databaseEntities Data = new Hat_Bazar_databaseEntities();




        //public ActionResult loginmodel()
        //{
        //    return View();
        //}

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(MyUserAccount user)
        {
            //if (ModelState.IsValid)
            //{
            //    return RedirectToAction("Index", Account.Login(user));
            //}
            using (Hat_Bazar_databaseEntities Data = new Hat_Bazar_databaseEntities())
            {
                try
                {
                    var usr = Data.Customer_Information.Single(u => u.User_id == user.UserName && u.Password == user.Password);
                    if (usr != null)
                    {
                        Session["Customer_id"] = usr.Customer_id.ToString();
                        Session["UserName"] = usr.User_id.ToString();

                        int i = Data.Customer_Order.Count(x => x.Purches_id == usr.Customer_id.ToString() && x.Order_Status == 1);
                        Session["Cart"] = i.ToString();
                        return RedirectToAction("Index", "Home");
                       



                    }
                    else
                    {
                        ModelState.AddModelError("", "User Name Or Password is wrong");
                    }
                }

                catch
                {
                    ModelState.AddModelError("", "User Name Or Password is wrong");
                }

            } 

            //else
            //{ ModelState.AddModelError("", "User Name Or Password is wrong");
            //}

            return View();
        }


        //public ActionResult MyPage()
        //{
        //    if (Session["Customer_id"] != null)
        //    {

        //        return View(Account.GetMyPage(Convert.ToInt32(Session["Customer_id"])));
        //    }
        //    else
        //    {
        //        return RedirectToAction("Login");
        //    }

        //}


        //[HttpPost]
        //public ActionResult MyPage(Customer_Information information)
        //{


        //    if (ModelState.IsValid)
        //    {
        //     TempData["Message"] = Account.PostMyPage(information);
        //      }

        //    else
        //    {
        //            TempData["Message"] = "Wrong Input";
        //     }


        //    return View();

        //}

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");


            }
        }
}