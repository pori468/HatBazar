using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HatBazar.Models;
using HatBazar.Interface;
using HatBazar.Methods;


//using System.Web.Helpers; 


namespace HatBazar.Controllers
{
    public class Email_ServiceController : Controller
    {
        private readonly IEmail_Service Email;
        public Email_ServiceController()
        {
            Email = new Email_ServiceClass();

        }

        public ActionResult SendEmail()
            {

                return View();
            }


        [HttpPost]
        public ActionResult SendEmail(Email_Service_Model obj)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    string Result = Email.SendEmail(obj);

                    TempData["Message"] = Result;

                }
                catch (Exception)
                {

                    TempData["Message"] = "Problem while sending email, Please check details.";


                }
            }
            return RedirectToAction("SendEmail");
          
            }

        }

    }
   




