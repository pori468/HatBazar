using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HatBazar.Models;

namespace HatBazar.Interface
{
    interface ICart
    {
        List<Customer_Order> Index(string Customer_Id);
        string Edit(string customer_id,int ? id);
        string Delete(string customer_id, int? id);
        string Submit( string sublit, string UserName);
    }
}
