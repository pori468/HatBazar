using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HatBazar.Models;
using HatBazar.Interface;
using System.Web.Helpers;
namespace HatBazar.Methods
{
    public class Email_ServiceClass : IEmail_Service
    {
        string IEmail_Service.SendEmail(Email_Service_Model obj)
        { try
            {
                //Configuring webMail class to send emails  
                //gmail smtp server  
                WebMail.SmtpServer = "smtp.gmail.com";
                //gmail port to send emails  
                WebMail.SmtpPort = 587;
                WebMail.SmtpUseDefaultCredentials = true;
                //sending emails with secure protocol  
                WebMail.EnableSsl = true;
                //EmailId used to send emails from application  
                WebMail.UserName = "pori468@gmail.com";
                WebMail.Password = "asmani6633";

                //Sender email address.  
                WebMail.From = "pori468@gmail.com";

                //Send email  
                WebMail.Send(to: obj.ToEmail, subject: obj.EmailSubject, body: obj.EMailBody, cc: obj.EmailCC, bcc: obj.EmailBCC, isBodyHtml: true);
                //ViewBag.Status = "Email Sent Successfully.";

                return "Email Sent Successfully.";
            }
            catch
            {
                return "Problem while sending email, Please check details.";
            }


            
        }

    }
}