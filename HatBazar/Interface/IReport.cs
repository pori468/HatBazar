using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HatBazar.Models;

namespace HatBazar.Interface
{
    interface IReport
    {
        int Product(OfferModel MyData);
        int Order(OfferModel MyData);
        List<Product_SellingDate> ProductToPDF();
    }
}
