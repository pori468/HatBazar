using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;


namespace HatBazar.Interface
{
     interface IEmail_Service
    {

        string SendEmail(HatBazar.Models.Email_Service_Model Obj);
    }
}
