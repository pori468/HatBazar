using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HatBazar.Models;
using HatBazar.Interface;
using HatBazar.Methods;

namespace HatBazar.Controllers
{
    public class ReportController : Controller
    {

        private Hat_Bazar_databaseEntities Data;
        private readonly IReport Report;
        public ReportController()
        {
            Report = new ReportClass();
            Data = new Hat_Bazar_databaseEntities();
        }


        
        // GET: Report
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Index(OfferModel mydata)
        {

           
                int result = Report.Order(mydata);


                if (result == 0)
                {
                   
                    return View();

                }


                else
                {
                  
                    return RedirectToAction("Product");

                }
            

           

        }


        public ActionResult Rubel(int? id ,int ?dd)
        {
            return View();
        }

        public ActionResult Product( )
        {


            return View(Report.ProductToPDF());
            
        }

        public ActionResult Order()
        {
            List<Order_with_Date> Order = Data.Order_with_Date.Where(x => x.Selected == 1).ToList();
            return View(Order);

        }
    }
}