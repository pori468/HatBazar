using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HatBazar.Models;
using System.IO;
using System.Web.Helpers;
using HatBazar.Interface;
using HatBazar.Methods;

namespace HatBazar.Controllers
{
    public class CarrierController : Controller
    {
        private Hat_Bazar_databaseEntities Data;
        private readonly ICarrier Carrier;
        public CarrierController()
        {
            Carrier = new CarrierClass();
            Data= new Hat_Bazar_databaseEntities();
        }

      
        // GET: AdminJob_Application
        public ActionResult Index()
            {
            if (Session["Customer_id"] != null)
            {


                if (Session["UserName"].ToString() == "ADMIN1" || Session["UserName"].ToString() == "ADMIN2")
                {

                    return View(Carrier.Index());
                }
                else
                { return RedirectToAction("Index", "Home"); }
            }
            else
            {
                return RedirectToAction("Login", "MyAccount");
            }
            
            }

            // GET: AdminJob_Application/Details/5
            public ActionResult Details(string id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                
                if (Carrier.Details(id) == null)
                {
                    return HttpNotFound();
                }
                return View(Carrier.Details(id));
            }


        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }


        [HttpPost]
        public ActionResult Create(JobApplication myform)
        {
            if (ModelState.IsValid)
            {
                TempData["Message"]= Carrier.Create(myform);
            }


           
            return View();
        }



        
        // GET: AdminJob_Application/Edit/5
        public ActionResult Edit(string id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
               
                if (Carrier.GetEdit(id) == null)
                {
                    return HttpNotFound();
                }
                return View(Carrier.GetEdit(id));
            }

            // POST: AdminJob_Application/Edit/5
            
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit([Bind(Include = "Application_id,First_name,Last_name,Address,Phone,Email,Gender,DateOfBirth,Marrage_status,Last_degree,Year,Subject,Post,About")] Job_Application job_Application)
            {
                if (ModelState.IsValid)
                {
                   
                    return RedirectToAction(Carrier.PostEdit(job_Application));
                }
                return View(job_Application);
            }

            // GET: AdminJob_Application/Delete/5
            public ActionResult Delete(string id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
               
                if (Carrier.GetDelete(id) == null)
                {
                    return HttpNotFound();
                }
                return View(Carrier.GetDelete(id));
            }

            // POST: AdminJob_Application/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public ActionResult DeleteConfirmed(string id)
            {
               
                return RedirectToAction(Carrier.PostDelete(id));
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
