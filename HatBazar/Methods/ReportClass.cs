using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HatBazar.Interface;
using HatBazar.Models;
using HatBazar.Utilities;
using System.Data.Entity;
using System.IO;
using System.Text;



namespace HatBazar.Methods
{
    public class ReportClass :IReport
    {
        Hat_Bazar_databaseEntities Data = new Hat_Bazar_databaseEntities();
        Utility Utility = new Utility();
        public int Product(OfferModel MyData)
        {
            DateTime start = Convert.ToDateTime(MyData.startdate + "/" + MyData.startmonth + "/" + MyData.startyear);
            DateTime end = Convert.ToDateTime(MyData.Enddate + "/" + MyData.Endmonth + "/" + MyData.Endyear);

            //var dateOnlyString = MyData.StartDate.ToShortDateString(); //Return 00/00/0000
            //DateTime start = Convert.ToDateTime(dateOnlyString);

            //dateOnlyString = MyData.EndDate.ToShortDateString(); //Return 00/00/0000
            //DateTime end = Convert.ToDateTime(dateOnlyString);
            if (Utility.CompareDate((end.Date).ToString(), (start.Date).ToString()))
            {


                List<Product_SellingDate> Product = Data.Product_SellingDate.ToList();
                foreach (var i in Product)
                {
                    i.Selected = 0;
                    Data.Entry(i).State = EntityState.Modified;
                    Data.SaveChanges();
                    if (Utility.CompareDate((end.Date).ToString(), i.Date))
                    {
                        if (Utility.CompareDate(i.Date, (start.Date).ToString()))
                        {
                            i.Selected = 1;
                            Data.Entry(i).State = EntityState.Modified;
                            Data.SaveChanges();
                        }
                    }


                  }

                    return 1;


                
            }
            else
            {
                return 0;
            }

            //return 0;            

        }


        public int Order(OfferModel MyData)
        {
            DateTime start = Convert.ToDateTime(MyData.startdate + "/" + MyData.startmonth + "/" + MyData.startyear);
            DateTime end = Convert.ToDateTime(MyData.Enddate + "/" + MyData.Endmonth + "/" + MyData.Endyear);

            //var dateOnlyString = MyData.StartDate.ToShortDateString(); //Return 00/00/0000
            //DateTime start = Convert.ToDateTime(dateOnlyString);

            //dateOnlyString = MyData.EndDate.ToShortDateString(); //Return 00/00/0000
            //DateTime end = Convert.ToDateTime(dateOnlyString);
            if (Utility.CompareDate((end.Date).ToString(), (start.Date).ToString()))
            {


                List<Order_with_Date> Product = Data.Order_with_Date.ToList();
                foreach (var i in Product)
                {
                    i.Selected = 0;
                    Data.Entry(i).State = EntityState.Modified;
                    Data.SaveChanges();
                    if (Utility.CompareDate((end.Date).ToString(), i.Date))
                    {
                        if (Utility.CompareDate(i.Date, (start.Date).ToString()))
                        {
                            i.Selected = 1;
                            Data.Entry(i).State = EntityState.Modified;
                            Data.SaveChanges();
                        }
                    }


                }

                return 1;



            }
            else
            {
                return 0;
            }

            //return 0;            

        }


        public List<Product_SellingDate> ProductToPDF()
        {

            try
            {
return Data.Product_SellingDate.Where(x => x.Selected == 1).ToList();
            }

            catch
            {
                throw;
            }
        }
    }
}