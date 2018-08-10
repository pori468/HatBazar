using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using HatBazar.Models;
using HatBazar.Interface;
using HatBazar.Methods;

namespace HatBazar.Controllers


{
    public class OfferController : Controller
    {

        private Hat_Bazar_databaseEntities Data;
        private readonly IOffer Offer;
        public OfferController()
        {
            Offer = new OfferClass();
            Data = new Hat_Bazar_databaseEntities();
        }
        
        // GET: Offer
        public ActionResult Index()
        {

            if (Session["Customer_id"] != null)
            {
                return View(Offer.Index());
               
            }
            else
            {
                return RedirectToAction("Login", "MyAccount");
            }



        }

        public ActionResult Details( int ? id)
        {
            if (Session["Customer_id"] != null)
            {
                
return View(Offer.Details(id.Value));
                   
                
            }
            else
            {
                return RedirectToAction("Login", "MyAccount");
            }


            
        }

        public ActionResult Delete(int? id)
        {
            if (Session["Customer_id"] != null)
            {
                if (Session["UserName"].ToString() == "ADMIN1" || Session["UserName"].ToString() == "ADMIN2")
                {

             TempData["Message"] = Offer.Delete(id.Value);
            return RedirectToAction("Index");
                }
                else
                { return RedirectToAction("Index", "Home"); }
            }
            else
            {
                return RedirectToAction("Login", "MyAccount");
            }
            
        }


        public ActionResult Delete_Package(int? id)
        {
            if (Session["Customer_id"] != null)
            {
                if (Session["UserName"].ToString() == "ADMIN1" || Session["UserName"].ToString() == "ADMIN2")
                {
 return RedirectToAction("Details", new { id = Offer.Delete_Package(id.Value) });
                    
                }
                else
                { return RedirectToAction("Index", "Home"); }
            }
            else
            {
                return RedirectToAction("Login", "MyAccount");
            }
           
        }

        


        public ActionResult Edit(int? id)
        {
            if (Session["Customer_id"] != null)
            {
                if (Session["UserName"].ToString() == "ADMIN1" || Session["UserName"].ToString() == "ADMIN2")
                {
return RedirectToAction("Details", new { id = id.Value });
                    
                }
                else
                { return RedirectToAction("Index", "Home"); }
            }
            else
            {
                return RedirectToAction("Login", "MyAccount");
            }

            

        }

         public ActionResult Edit_Package(int? id)
        {

            if (Session["Customer_id"] != null)
            {
                if (Session["UserName"].ToString() == "ADMIN1" || Session["UserName"].ToString() == "ADMIN2")
                {
return RedirectToAction("Details", new { id = id.Value });
                    
                }
                else
                { return RedirectToAction("Index", "Home"); }
            }
            else
            {
                return RedirectToAction("Login", "MyAccount");
            }
            

        }


        public ActionResult PackageDetails(int? id)
        {
            if (Session["Customer_id"] != null)
            {
                 TempData["Package_id"] = id.Value;
            return View(Offer.PackageDetails(id.Value));
                                   
            }
            else
            {
                return RedirectToAction("Login", "MyAccount");
            }

          
        
           
                
        }


        public ActionResult Add_Package_ToCart(int? id)
        {

            if (Session["Customer_id"] != null)
            {

                Session["Cart"] = Offer.Add_Package_ToCart(id.Value, (Session["Customer_id"]).ToString());

                
                    return RedirectToAction("Details", new { id = Offer.campaignId(id.Value) });

               
            }
            else
            {
                return RedirectToAction("Login", "MyAccount");
            }

        }
        public ActionResult Add(int? id)
        {

            if (Session["Customer_id"] != null)
            {
                if (Session["UserName"].ToString() == "ADMIN1" || Session["UserName"].ToString() == "ADMIN2")
                {
 if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            else
            {                
                return RedirectToAction("PackageDetails", new { id = Offer.Add(id.Value, Convert.ToInt32(TempData["Package_id"])) });

            }
                   
                }
                else
                { return RedirectToAction("Index", "Home"); }
            }
            else
            {
                return RedirectToAction("Login", "MyAccount");
            }

           

           

        }



        // GET: Cart/Delete/5
        public ActionResult Remove(int? id)
        {

            if (Session["Customer_id"] != null)
            {
                if (Session["UserName"].ToString() == "ADMIN1" || Session["UserName"].ToString() == "ADMIN2")
                {
 if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

             return RedirectToAction("PackageDetails", new { id = Offer.Remove(id.Value, Convert.ToInt32(TempData["Package_id"])) });

                   
                }
                else
                { return RedirectToAction("Index", "Home"); }
            }
            else
            {
                return RedirectToAction("Login", "MyAccount");
            }
           
        }

        public ActionResult Create()
        {
            if (Session["Customer_id"] != null)
            {
                if (Session["UserName"].ToString() == "ADMIN1" || Session["UserName"].ToString() == "ADMIN2")
                {

                    return View();
                }
                else
                { return RedirectToAction("Index", "Home"); }
            }
            else
            {
                return RedirectToAction("Login", "MyAccount");
            }
            
        }

        [HttpPost]
        public ActionResult Create(OfferModel mydata)
        {
            if (Session["Customer_id"] != null)
            {
                if (Session["UserName"].ToString() == "ADMIN1" || Session["UserName"].ToString() == "ADMIN2")
                {
if (ModelState.IsValid)
            {
                int result = Offer.Create(mydata);


                if (result != 0)
            {
                    TempData["Package_Id"] = result;
                    TempData["Campaign_ID"] = Offer.campaignId(Convert.ToInt32(TempData["Package_Id"]));
                    return RedirectToAction("Item");

            }


            else
            {
                TempData["Message"] = "Wrong Date";
                return RedirectToAction("Create");

            }
            }
            else
            {
                TempData["Message"] = "Wrong Data ";
                return View();

            }

                    
                }
                else
                { return RedirectToAction("Index", "Home"); }
            }
            else
            {
                return RedirectToAction("Login", "MyAccount");
            }
            



        }
        
        public ActionResult Item()
        {
            if (Session["Customer_id"] != null)
            {
                if (Session["UserName"].ToString() == "ADMIN1" || Session["UserName"].ToString() == "ADMIN2")
                {
return View(Offer.Item());
                    
                }
                else
                { return RedirectToAction("Index", "Home"); }
            }
            else
            {
                return RedirectToAction("Login", "MyAccount");
            }
            

        }

        public ActionResult AddtoPackaget(int? id)
        {
            if (Session["Customer_id"] != null)
            {
                if (Session["UserName"].ToString() == "ADMIN1" || Session["UserName"].ToString() == "ADMIN2")
                {
if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            else
            {
                TempData["Message"] = Offer.AddtoPackaget(id.Value, Convert.ToInt32(TempData["Package_Id"]));
                return RedirectToAction("Item");

            }
                    
                }
                else
                { return RedirectToAction("Index", "Home"); }
            }
            else
            {
                return RedirectToAction("Login", "MyAccount");
            }
            


        }


        public ActionResult Create_Package()
        {
            if (Session["Customer_id"] != null)
            {
                if (Session["UserName"].ToString() == "ADMIN1" || Session["UserName"].ToString() == "ADMIN2")
                {

                    return View();
                }
                else
                { return RedirectToAction("Index", "Home"); }
            }
            else
            {
                return RedirectToAction("Login", "MyAccount");
            }
            
        }

        // POST: Package/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create_Package(Package p)
        {
            if (Session["Customer_id"] != null)
            {
                if (Session["UserName"].ToString() == "ADMIN1" || Session["UserName"].ToString() == "ADMIN2")
                {
if (ModelState.IsValid)
            {
                int result = Offer.Create_Package(p, Convert.ToInt32(TempData["Campaign_ID"]));
                if (result == 0)
                {
                    TempData["Message"] = "Enter a Uniq Package Name ";
                    return View();
                }

                else
                {


                    TempData["Package_Id"] = result;
                    return RedirectToAction("Item");
                }
            }

            else
            {
                TempData["Message"] = "Wrong Data ";
                return View();

            }

                   
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