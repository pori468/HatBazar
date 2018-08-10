using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HatBazar.Models;

namespace HatBazar.Interface
{
    interface IOffer
    {
        List<Campaign> Index();
        List<Package>Details(int id);
        List<Package_With_Product> PackageDetails(int id);
        int Add(int product , int pack);
        int Remove(int product, int pack);
        int Create(OfferModel MyData);
        List<Product_Information> Item();
        string AddtoPackaget(int id, int package_id);
        int Create_Package(Package package, int Campaign_Id);
        int Add_Package_ToCart(int Package_id, string customerid);

        int Delete_Package(int Id);
        string Delete(int campign_Id);
        int campaignId(int id);
    }
}
