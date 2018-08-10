using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HatBazar.Interface;
using HatBazar.Models;
using HatBazar.Utilities;
using System.Data;
using System.Data.Entity;

namespace HatBazar.Methods
{
    public class OfferClass : IOffer
    {
        Hat_Bazar_databaseEntities Data = new Hat_Bazar_databaseEntities();
        Utility Utility = new Utility();
        public List<Campaign> Index()
        {
            List<Campaign> campaign = Data.Campaign.ToList();


            foreach (var i in campaign)
            {


                //if (!Utility.CompareDate(null, i.Validity_End))
                //{
                    if (Utility.CompareDate(i.Validity, null))
                    {
                        i.Validation = 0;
                        Data.Entry(i).State = EntityState.Modified;
                        Data.SaveChanges();
                    }



                //}

            }
            return Data.Campaign.Where(x => x.Validation == 1).ToList();
        }

       public List<Package> Details(int id)
        {
            try {
                return Data.Package.Where(x=>x.Campaign_Id== id).ToList();

            }

            catch {
                throw;
            }
        }


        public int Add_Package_ToCart(int Package_id, string customerid)
        {
            try
            {
Package PP = Data.Package.Single(x => x.Package_Id == Package_id);

            Customer_Order CO = new Customer_Order();
            CO.Product_Name = PP.Package_Name;
            CO.Unit_name = "PACKAGE";
            CO.Unit_number = 1;
            CO.Price = PP.Price;
            CO.Purches_id = customerid;
            CO.Product_id = PP.Package_Id;
            CO.Order_Status = 1;
            Data.Customer_Order.Add(CO);
            Data.SaveChanges();

            return Data.Customer_Order.Count(x => x.Purches_id == customerid && x.Order_Status == 1);
            }


            catch
            {
                throw;
            }




        }
        public int Add(int product_id, int Package_Id)
                {


                    try
                    {



                        Package_With_Product modify = Data.Package_With_Product.Single(x => x.Package_Id == Package_Id && x.Product_Id == product_id);

                        modify.Unit_Number = modify.Unit_Number + 1;
                        Data.Entry(modify).State = EntityState.Modified;
                        Data.SaveChanges();
                        return modify.Package_Id;


                    }

                    catch
                    {
                        throw;
                    }
                }


        public int Remove(int product_id, int Package_Id)
        {

            try
            {





                bool check = Data.Package_With_Product.Any(x => x.Package_Id == Package_Id && x.Product_Id == product_id);
                if (check)
                {
                    Package_With_Product modify = Data.Package_With_Product.Single(x => x.Package_Id == Package_Id && x.Product_Id == product_id);
                    if (modify.Unit_Number > 1)
                    {
                        modify.Unit_Number--;
                        Data.Entry(modify).State = EntityState.Modified;

                    }

                    else
                    {
                        Data.Package_With_Product.Remove(modify);

                    }

                    Data.SaveChanges();
                    return modify.Package_Id;

                }

                return 0;
            }

            catch
            {
                throw;
            }
        }

        public  List<Package_With_Product> PackageDetails(int id)
        {
            
                try
                {
                    return Data.Package_With_Product.Where(x => x.Package_Id == id).ToList();

                }

                catch
                {
                    throw;
                }

            
        }


        public int campaignId(int id)
        {
            try { 

             Package C = Data.Package.Single(x => x.Package_Id == id);

                return C.Campaign_Id;
            }

            catch
            {
                throw;
            }
        }
       public string Delete(int campign_Id)
        {
            try
            {
                List<Package> Packages = Data.Package.Where(x => x.Campaign_Id == campign_Id).ToList();

                foreach (var i in Packages)
                {

                    List<Package_With_Product> PP = Data.Package_With_Product.Where(x => x.Package_Id == i.Package_Id).ToList();

                    foreach (var j in PP)
                    {
                        Data.Package_With_Product.Remove(j);
                        Data.SaveChanges();

                    }
                    Data.Package.Remove(i);
                    Data.SaveChanges();
                }

                Campaign campaign = Data.Campaign.Find(campign_Id);
                Data.Campaign.Remove(campaign);
                Data.SaveChanges();

                return "Data Deleted Successfully";
            }

            catch
            {

                return "Data not Deleted";
            }


        }


      public  int Delete_Package(int Id)
        {
            try
            {
                Package p = Data.Package.Single(x=>x.Package_Id==Id);
                int campaignid = p.Campaign_Id; 
               List<Package_With_Product> PP = Data.Package_With_Product.Where(x => x.Package_Id == Id).ToList();

                    foreach (var j in PP)
                    {
                        Data.Package_With_Product.Remove(j);
                        Data.SaveChanges();

                    }
                    Data.Package.Remove(p);
                    Data.SaveChanges();


                return campaignid;
            }

            catch
            {

                throw;
            }

        }

        public int Create(OfferModel MyData)
        {
            DateTime start = Convert.ToDateTime(MyData.startdate + "/" + MyData.startmonth + "/" + MyData.startyear);
            DateTime end = Convert.ToDateTime(MyData.Enddate + "/" + MyData.Endmonth + "/" + MyData.Endyear);

            //var dateOnlyString = MyData.StartDate.ToShortDateString(); //Return 00/00/0000
            //DateTime start = Convert.ToDateTime(dateOnlyString);

            //dateOnlyString = MyData.EndDate.ToShortDateString(); //Return 00/00/0000
            //DateTime end = Convert.ToDateTime(dateOnlyString);
            if (Utility.CompareDate((DateTime.Now.Date).ToString(), (start.Date).ToString()))
            {
                if (Utility.CompareDate((start.Date).ToString(), (end.Date).ToString()))

                {
                   
                        Campaign campaign = new Campaign();
                        Package pack = new Package();

                        if (MyData.Campaign_Name == null)
                            return 0;
                        else
                        {
                            campaign.Campaign_Name = MyData.Campaign_Name;
                            campaign.Validity = (start.Date).ToString();
                            campaign.Validity_End = (end.Date).ToString();
                            campaign.Validation = 1;
                            Data.Campaign.Add(campaign);

                            pack.Package_Name = MyData.Package_Name;
                            pack.Price = MyData.Price;
                            pack.Campaign_Id = campaign.Campaign_ID;

                            Data.Package.Add(pack);

                            Data.SaveChanges();
                            return pack.Package_Id;
                        }
                    
                   

                }
                else
                {
                    return 0;
                }
            }


            else
            {
                return 0;
            }


        }

        public List<Product_Information> Item()
        {
            try
            {
                return Data.Product_Information.Include(p => p.Image).ToList();
            }
            catch
            {

                throw;
            }


        }

        public string AddtoPackaget(int id, int package_id)
        {


            Package_With_Product PP = new Package_With_Product();

            bool check = Data.Package_With_Product.Any(x => x.Package_Id == package_id && x.Product_Id == id);
            if (check)
            {
                Package_With_Product modify = Data.Package_With_Product.Single(x => x.Package_Id == package_id && x.Product_Id == id);

                modify.Unit_Number = modify.Unit_Number + 1;
                Data.Entry(modify).State = EntityState.Modified;
                Data.SaveChanges();

                return "Product unit is Modified .";
            }

            else
            {

                Product_Information PI = Data.Product_Information.Include(Y => Y.Image).Single(x => x.Product_id == id);
                Package Package = Data.Package.Single(x=>x.Package_Id==package_id);


                PP.Package_Id = package_id;
                PP.Package_Name = Package.Package_Name;
                PP.Product_Id = id;
                PP.Unit_Number = 1;
                PP.Unit_Name = PI.Unit;
                PP.Product_Name = PI.Product_name;
                PP.Photo = PI.Image.Image1;


                Data.Package_With_Product.Add(PP);

                Data.SaveChanges();
                return "Product Added Successfully.";


            }

        }

        public int Create_Package(Package package, int Campaign_Id)
        {
            try
            {

                bool check = Data.Package.Any(x => x.Package_Name == package.Package_Name);

                if (check)
                {
                    return 0;
                }
                else
                {
                    Package pack = new Package();



                    pack.Package_Name = package.Package_Name;
                    pack.Price = package.Price;
                    pack.Campaign_Id = Campaign_Id;

                    Data.Package.Add(pack);
                    Data.SaveChanges();
                    var i = pack.Package_Id;
                    return pack.Package_Id;
                }
            }

            catch
            {
                return 0;

            }

        }
    }
}
     
   
