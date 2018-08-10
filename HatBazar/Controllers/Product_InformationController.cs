using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HatBazar.Models;
using HatBazar.Methods;
using HatBazar.Interface;
using PagedList;
using PagedList.Mvc;


namespace HatBazar.Controllers
{
    public class Product_InformationController : Controller
    {
        private Hat_Bazar_databaseEntities Data;
        private readonly IProduct_Information Product;

        public Product_InformationController()
        {
            Product = new Product_InformationClass();
            Data = new Hat_Bazar_databaseEntities();
        }
       



       
        public ActionResult Index(string option, string search, int? Type, int? page)
        {
                      
            if (Session["Customer_id"] != null)
            {
                try
                {
                    List<Product_Information>p = Product.Index(option, search, Type);
                    return View(p.ToPagedList(page ?? 1,8));
                }

                catch
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                }

            }
            else
            {
                return RedirectToAction("Login", "MyAccount");
            }



        }



        // GET: Product_Information/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["Customer_id"] != null)
            {               
                    try
                    {
                    return View(Product.Details(id.Value));

                    }
                    catch
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                   
               
               
            }
            else
            {
                return RedirectToAction("Login", "MyAccount");
            }


            
        }


        // GET: AdminProduct_Information1/Create
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
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductModel product_Information)
        {
            if (Session["Customer_id"] != null)
            {
                if (Session["UserName"].ToString() == "ADMIN1" || Session["UserName"].ToString() == "ADMIN2")
                {
return RedirectToAction(Product.Create(product_Information));

                }
                else
                { return RedirectToAction("Index", "Home"); }
            }
            else
            {
                return RedirectToAction("Login", "MyAccount");
            }
            
        }

        // GET: AdminProduct_Information1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["Customer_id"] != null)
            {
                if (Session["UserName"].ToString() == "ADMIN1" || Session["UserName"].ToString() == "ADMIN2")
                {

if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            if (Product.GetEdit(id.Value) == null)
            {
                return HttpNotFound();
            }
           
            return View(Product.GetEdit(id.Value));
                }
                else
                { return RedirectToAction("Index", "Home"); }
            }
            else
            {
                return RedirectToAction("Login", "MyAccount");
            }
            
        }

        // POST: AdminProduct_Information1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductModel product_Information)
        {
            if (Session["Customer_id"] != null)
            {
                if (Session["UserName"].ToString() == "ADMIN1" || Session["UserName"].ToString() == "ADMIN2")
                {
                if (ModelState.IsValid)
            {
                
                return RedirectToAction(Product.PostEdit(product_Information));
            }
            
            return View(product_Information);

                }
                else
                { return RedirectToAction("Index", "Home"); }
            }
            else
            {
                return RedirectToAction("Login", "MyAccount");
            }
            
        }

        // GET: AdminProduct_Information1/Delete/5
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
           
            if (Product.GetDelete(id.Value) == null)
            {
                return HttpNotFound();
            }
            return View(Product.GetDelete(id.Value));

                }
                else
                { return RedirectToAction("Index", "Home"); }
            }
            else
            {
                return RedirectToAction("Login", "MyAccount");
            }
            
        }

        // POST: AdminProduct_Information1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["Customer_id"] != null)
            {
                if (Session["UserName"].ToString() == "ADMIN1" || Session["UserName"].ToString() == "ADMIN2")
                {

 return RedirectToAction(Product.PostDelete(id));
                }
                else
                { return RedirectToAction("Index", "Home"); }
            }
            else
            {
                return RedirectToAction("Login", "MyAccount");
            }
           
        }



        public ActionResult SubCategory(int id)
        {
            //ViewBag.SubcategoryId = id;

            //var subcats = Data.Categories.Where(x => x.Parent_id == id);

            //var lst = new List<Product_Information>();
            //foreach(var i in subcats)
            //{
            //    var allProducts = Data.Product_Information.Where(x =>x.Category_id==i.Id);
            //    lst.AddRange(allProducts);

            //}

            //return RedirectToAction("Index");

            //
            //Index(id);
            return View();
        }


        public ActionResult Addtocart(int? id)
        {
            if (Session["Customer_id"] != null)
            {
                TempData["Message"] = Product.Addtocart(id.Value, (Session["Customer_id"]).ToString());

                string customerId = Session["Customer_id"].ToString();
                int i = Data.Customer_Order.Count(x => x.Purches_id == customerId && x.Order_Status == 1);
                Session["Cart"] = i.ToString();

                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Login", "MyAccount");
            }

            
        }

        public ActionResult Status(int? id)
        {
            if (Session["Customer_id"] != null)
            {
                if (Session["UserName"].ToString() == "ADMIN1" || Session["UserName"].ToString() == "ADMIN2")
                {
return View(Product.Status(id.Value));

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
