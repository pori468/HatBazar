using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HatBazar.Models;
using System.IO;
using System.Web.Helpers;
using HatBazar.Methods;
using HatBazar.Interface;
using System.Data;
using System.Net;


namespace HatBazar.Controllers
{
    public class FooterController : Controller
    {
        private Hat_Bazar_databaseEntities Data;
        private readonly IFooter Foot;
        public FooterController()
        {
            Foot = new FooterClass();
            Data =  new Hat_Bazar_databaseEntities();
        }

        // GET: Footer
        public ActionResult FindUs()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Complain()
        {
            return View();
        }
        
     
       [HttpPost]
        public ActionResult Complain(Complain complain)
        {
            if (ModelState.IsValid)
            {

                TempData["Message"] = Foot.Complain(complain);     
                
               
            }
                    return View();
        }


        [HttpGet]
        public ActionResult ShowComplain()
        {

            return View(Foot.ShowComplain());
        }

        
        public ActionResult Status( int id)
        {

            return RedirectToAction("ShowComplain", Foot.PostShowComplain(id));
        }

        public ActionResult ComplainDetails(int ? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            if (Foot.ComplainDetails(id.Value) == null)
            {
                return HttpNotFound();
            }
            return View(Foot.ComplainDetails(id.Value));

        }





        public ActionResult Contac()
        {
            return View();
        }

        public ActionResult Policies()
        {
            return View();
        }
    }
}