using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HatBazar.Models;

namespace HatBazar.Interface
{
    interface ICustomer_Information
    {
        List<Customer_Information> Index();
        Customer_Information Details( int? id);
        Customer_Information GetDelete(int? id);
        string PostDelete(int? id);
        string Register(MyUserAccount Account);
        Customer_Information GetMyPage(int CustomerId);
        string PostMyPage(Customer_Information MyInfo);
    }
}
