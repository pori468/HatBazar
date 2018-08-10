using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Net;
using HatBazar.Models;
using HatBazar.Interface;
using HatBazar.Methods;

namespace HatBazar.Controllers

{
    public class Customer_InformationController : Controller
    {
        
            
        private Hat_Bazar_databaseEntities Data;
        private readonly ICustomer_Information Info;
        public Customer_InformationController()
        {
            Info = new Customer_InformationClass();
            Data = new Hat_Bazar_databaseEntities();
        }


        // GET: AdminCustomer_Information
        public ActionResult Index()
            {
            if (Session["Customer_id"] != null)
            {

                if (Session["UserName"].ToString() == "ADMIN1" || Session["UserName"].ToString() == "ADMIN2")
                {
                    return View(Info.Index());

                }
                else
                { return RedirectToAction("Index", "Home"); }
            }
            else
            {
                return RedirectToAction("Login", "MyAccount");
            }
            
            }

        // GET: AdminCustomer_Information/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["Customer_id"] != null)
            {

                if (Session["UserName"].ToString() == "ADMIN1" || Session["UserName"].ToString() == "ADMIN2")
                {
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }

                    if (Info.Details(id) == null)
                    {
                        return HttpNotFound();
                    }
                    return View(Info.Details(id));



                }
                else
                { return RedirectToAction("Index", "Home"); }
            }
            else
            {
                return RedirectToAction("Login", "MyAccount");
            }

        }


        // GET: AdminCustomer_Information/Create
        public ActionResult Register()
        {
            return View();
        }

        // POST: AdminCustomer_Information/Create
        [HttpPost]
        public ActionResult Register(MyUserAccount account)
        {
            if (ModelState.IsValid)
            {

                ModelState.Clear();

                ViewBag.Message = Info.Register(account);
            }
            return View();
        }



        public ActionResult MyPage()
        {
            if (Session["Customer_id"] != null)
            {

                return View(Info.GetMyPage(Convert.ToInt32(Session["Customer_id"])));
            }
            else
            {
                return RedirectToAction("Login");
            }

        }


        [HttpPost]
        public ActionResult MyPage(Customer_Information information)
        {


            if (ModelState.IsValid)
            {
                TempData["Message"] = Info.PostMyPage(information);
            }

            else
            {
                TempData["Message"] = "Wrong Input";
            }


            return View();

        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");


        }

        // GET: AdminCustomer_Information/Delete/5
        public ActionResult Delete(int? id)
            {
            if (Session["Customer_id"] != null)
            {

                if (Session["UserName"].ToString() == "ADMIN1" || Session["UserName"].ToString() == "ADMIN2")
                {
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    
                    if (Info.GetDelete(id) == null)
                    {
                        return HttpNotFound();
                    }
                    return View(Info.GetDelete(id));



                }
                else
                { return RedirectToAction("Index", "Home"); }
            }
            else
            {
                return RedirectToAction("Login", "MyAccount");
            }
            
            }

            // POST: AdminCustomer_Information/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public ActionResult DeleteConfirmed(int id)
            {
            if (Session["Customer_id"] != null)
            {

                if (Session["UserName"].ToString() == "ADMIN1" || Session["UserName"].ToString() == "ADMIN2")
                {


                   
                    return RedirectToAction(Info.PostDelete(id));



                }
                else
                { return RedirectToAction("Index", "Home"); }
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


