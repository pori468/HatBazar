using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HatBazar.Models;
using HatBazar.Interface;
using System.Data.Entity;
using System.IO;

namespace HatBazar.Methods
{
    public class CartClass :ICart
    {
        Hat_Bazar_databaseEntities Data = new Hat_Bazar_databaseEntities();

       public List<Customer_Order> Index(string Customer_Id)
        {
            try
            {
            List <Customer_Order> C =  Data.Customer_Order.Where(x => x.Purches_id == Customer_Id && x.Order_Status == 1).ToList();
                return C;
            }

            catch
            {
                throw;
            }

            
        }


        public string Edit(string customer_id, int? id)
        {
            try
            {
 Customer_Order Data_Amdani = Data.Customer_Order.Single(Z => Z.Id == id && Z.Purches_id == customer_id && Z.Order_Status == 1);

            if (Data_Amdani.Unit_name == "PACKAGE")
            {
                return "Sorry !! You cant get More then 1 Package";
            }


            else
            {
                Data_Amdani.Unit_number++;
                Data.Entry(Data_Amdani).State = EntityState.Modified;
                Data.SaveChanges();
                return Data_Amdani.Product_Name + " is successfully Incrimented.";
            }
        }

            catch
            {

                return "Missing Data";
            }
            }


        public string Delete(string customer_id, int? id)
        {
            try
            {
        Customer_Order Data_Amdani = Data.Customer_Order.Single(Z => Z.Id == id && Z.Purches_id == customer_id && Z.Order_Status == 1);
            if (Data_Amdani.Unit_number > 1)
            {
                Data_Amdani.Unit_number--;
                Data.Entry(Data_Amdani).State = EntityState.Modified;
               
            }

            else
            {
                Data.Customer_Order.Remove(Data_Amdani);
                              
            }
            Data.SaveChanges();
            return Data.Customer_Order.Count(x => x.Purches_id == customer_id && x.Order_Status == 1).ToString();
            }

            catch
            {
                throw;
            }
           
            
        }

        public string Submit(string Customer_id, string UserName)
        {
            try
            {
List<Customer_Order> submitionList = Data.Customer_Order.Where(x => x.Purches_id == Customer_id && x.Order_Status == 1).ToList();
            int Total = 0;
            System.Random rand = new System.Random((int)System.DateTime.Now.Ticks);
            int random = rand.Next(1, 100000000);

            string Path = @"D:\Repositories\HatBazar\Email_Document\Customer_Order\" + random + ".txt";
            //Pass the filepath and filename to the StreamWriter Constructor

            //StreamWriter sw = new StreamWriter(@"D:\Repositories\HatBazar\Email_Document\Admin_Email\Document.txt");
            StreamWriter sw = new StreamWriter(Path);

            //Write a line of text

            sw.WriteLine(System.IO.File.ReadAllText(@"D:\Repositories\HatBazar\Email_Document\Customer_Order\Order1.txt"));
            sw.WriteLine("Date :" + DateTime.Now);
            //***************************************************

            foreach (var i in submitionList)
            {
                if (i.Unit_name == "PACKAGE")
                {
                    int packageid = (i.Product_id).Value;
                    List<Package_With_Product> Item = Data.Package_With_Product.Where(x => x.Package_Id == packageid).ToList();
                    foreach (var product in Item)
                    {

                        Product_Stock CO = Data.Product_Stock.Single(Z => Z.Product_id == product.Product_Id);

                        int J = Int32.Parse(CO.Stock_unit);
                        J = J - product.Unit_Number;
                        CO.Stock_unit = J.ToString();
                        Data.Entry(CO).State = EntityState.Modified;

                        bool Check = Data.Order_For_Shop.Any(x => x.Product_Name == (product.Product_Name));
                        if (Check == true)
                        {
                            Order_For_Shop order = Data.Order_For_Shop.Single(Z => Z.Product_Name == product.Product_Name);

                            order.Unit_Number = product.Unit_Number + (order.Unit_Number);

                            var price = Data.Product_Information.Single(x => x.Product_id == order.Product_Id);
                            order.Total_Price = (order.Unit_Number) * (price.Price_per_unit);
                            Data.Entry(order).State = EntityState.Modified;
                            Product_SellingDate psd = new Product_SellingDate();
                            psd.Product_Id = order.Product_Id;
                            psd.Product_Name = order.Product_Name;
                            psd.Unit_Number = product.Unit_Number;
                            psd.Unit_Name = order.Unit_Name;
                            psd.Price = i.Price * product.Unit_Number;
                            psd.Selected = 0;
                            var dateTimeNow = DateTime.Now; // Return 00/00/0000 00:00:00
                            psd.Date = dateTimeNow.ToShortDateString();

                            Data.Product_SellingDate.Add(psd);
                            Data.SaveChanges();
                        }
                        else
                        {
                            Order_For_Shop OF = new Order_For_Shop();
                            OF.Product_Name = product.Product_Name;
                            OF.Unit_Name = product.Unit_Name;
                            OF.Unit_Number = product.Unit_Number;
                            var price = Data.Product_Information.Single(x => x.Product_id == OF.Product_Id);
                            OF.Total_Price = price.Price_per_unit;
                            Data.Order_For_Shop.Add(OF);

                            Product_SellingDate psd = new Product_SellingDate();
                            psd.Product_Id = OF.Product_Id;
                            psd.Product_Name = product.Product_Name;
                            psd.Unit_Number = product.Unit_Number;
                            psd.Unit_Name = product.Unit_Name;
                            psd.Price = i.Price * product.Unit_Number;
                            psd.Selected = 0;
                            var dateTimeNow = DateTime.Now; // Return 00/00/0000 00:00:00
                            psd.Date = dateTimeNow.ToShortDateString();

                            Data.Product_SellingDate.Add(psd);
                            Data.SaveChanges();
                        }




                    }

                }
                else
                {
                    Product_Stock CO = Data.Product_Stock.Single(Z => Z.Product_id == (i.Product_id).Value);

                    int J = Int32.Parse(CO.Stock_unit);
                    J = J - (i.Unit_number).Value;
                    CO.Stock_unit = J.ToString();
                    Data.Entry(CO).State = EntityState.Modified;

                    bool Check = Data.Order_For_Shop.Any(x => x.Product_Name == (i.Product_Name));
                    if (Check == true)
                    {
                        Order_For_Shop order = Data.Order_For_Shop.Single(Z => Z.Product_Name == i.Product_Name);

                        order.Unit_Number = (i.Unit_number).Value + (order.Unit_Number);
                            var price = Data.Product_Information.Single(x => x.Product_name == order.Product_Name);
                            //  var price = Data.Product_Information.Single(x => x.Product_id == order.Product_Id);
                            order.Total_Price = (order.Unit_Number) * (price.Price_per_unit);
                        Data.Entry(order).State = EntityState.Modified;

                        Product_SellingDate psd = new Product_SellingDate();
                        psd.Product_Id = order.Product_Id;
                        psd.Product_Id = order.Product_Id;
                        psd.Product_Name = order.Product_Name;
                        psd.Unit_Number = i.Unit_number;
                        psd.Unit_Name = order.Unit_Name;
                        psd.Price = price.Price_per_unit * i.Unit_number;
                        psd.Selected = 0;
                        var dateTimeNow = DateTime.Now; // Return 00/00/0000 00:00:00
                        psd.Date = dateTimeNow.ToShortDateString();

                        Data.Product_SellingDate.Add(psd);
                        Data.SaveChanges();




                    }
                    else
                    {
                        Order_For_Shop OF = new Order_For_Shop();
                        //OF.Product_Id = (i.Product_id).Value;
                        OF.Product_Name = i.Product_Name;
                        OF.Unit_Name = i.Unit_name;
                        OF.Unit_Number = (i.Unit_number).Value;
                        Data.Order_For_Shop.Add(OF);

                        Product_SellingDate psd = new Product_SellingDate();
                        psd.Product_Id = (i.Product_id).Value;


                        psd.Product_Name = i.Product_Name;
                        psd.Unit_Number = i.Unit_number;
                        psd.Unit_Name = i.Unit_name;
                        psd.Price = i.Price * i.Unit_number;
                        psd.Selected = 0;
                        var dateTimeNow = DateTime.Now; // Return 00/00/0000 00:00:00
                        psd.Date = dateTimeNow.ToShortDateString();

                        Data.Product_SellingDate.Add(psd);
                        Data.SaveChanges();
                    }


                }
                i.Order_Status = 0;
                var date = DateTime.Now;
                i.Date = date.ToShortDateString();
                Data.Entry(i).State = EntityState.Modified;




                //***********************************

                try
                {
                    string Information = "Product Name :" + i.Product_Name + "Unit :" + i.Unit_number + "" + i.Unit_name + "Price:" + (i.Unit_number * i.Price);
                    sw.WriteLine(Information);
                    Total = Total + (i.Unit_number * i.Price).Value;



                }

                catch
                {
                    return  "Path Missing to save Email.";
                }

                //***********************************



            }
            Order_with_Date OD = new Order_with_Date();

            var date2 = DateTime.Now;
            OD.Date = date2.ToShortDateString();

            OD.User_Name = UserName;
            OD.Total_Price = Total;
            Data.Order_with_Date.Add(OD);
            Data.SaveChanges();

            sw.WriteLine("Total : " + Total);
            sw.WriteLine(System.IO.File.ReadAllText(@"D:\Repositories\HatBazar\Email_Document\Customer_Order\Order2.txt"));
            sw.Close();




           
                 IEmail_Service email= new Email_ServiceClass();
                int ia = Int32.Parse(Customer_id);
                Customer_Information Info = Data.Customer_Information.Single(x => x.Customer_id ==ia );
                Email_Service_Model obj = new Email_Service_Model();

                obj.ToEmail = Info.Email;
                obj.EmailSubject = "Hat Bazar";
                obj.EMailBody = System.IO.File.ReadAllText(Path);

               return email.SendEmail(obj);

               
            
            

           
            }

            catch
            {

                return "Submission Failure";
            }
            

        }


    }
}