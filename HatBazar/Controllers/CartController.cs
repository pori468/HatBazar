using System;
using System.Collections.Generic;
using System.Data;

using System.Linq;
using System.Net;
using System.Web;
using System.IO;
using System.Web.Mvc;
using HatBazar.Models;
using System.Web.Helpers;
using HatBazar.Interface;
using HatBazar.Methods;

namespace HatBazar.Controllers
{
    public class CartController : Controller
    {
        private Hat_Bazar_databaseEntities Data;
        private readonly ICart Cart;

            public CartController()
            {
                Cart = new CartClass();
            Data = new Hat_Bazar_databaseEntities();
        }

            // GET: Cart
            public ActionResult Index()
        {
            if (Session["Customer_id"] != null)
            {   
                return View( Cart.Index( (Session["Customer_id"]).ToString()));

            }
            else
            {
                return RedirectToAction("Login","MyAccount");
            }
           
        }


        
        public ActionResult Edit(int? id)
        {
            if (Session["Customer_id"] != null)
            {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
  

                    TempData["Message"] = Cart.Edit((Session["Customer_id"]).ToString(),id) ;
                    return RedirectToAction("Index");
                }
            
            else
            {
                return RedirectToAction("Login", "MyAccount");
            }
            

        }

        

        // GET: Cart/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["Customer_id"] != null)
            {


if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

                Session["Cart"] =Cart.Delete((Session["Customer_id"]).ToString(), id);
                return RedirectToAction("Index");

            }
            else
            {
                return RedirectToAction("Login", "MyAccount");
            }
            
        }

        public ActionResult Submit()
        {
            if (Session["Customer_id"] != null)
            {
               
                TempData["Message"] = Cart.Submit((Session["Customer_id"]).ToString(),(Session["UserName"]).ToString());
            return View();

            }
            else
            {
                return RedirectToAction("Login", "MyAccount");
            }

           
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Data.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
