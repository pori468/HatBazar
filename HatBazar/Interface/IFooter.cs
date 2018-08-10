using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HatBazar.Models;

namespace HatBazar.Interface
{
    interface IFooter
    {
        string Complain(Complain comp);
        List<Customer_Complain> ShowComplain();
        List<Customer_Complain> PostShowComplain(int id );
        Customer_Complain ComplainDetails(int id);
    }
}
