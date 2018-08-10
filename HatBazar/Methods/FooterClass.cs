using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HatBazar.Interface;
using HatBazar.Models;
using System.IO;
using System.Data.Entity;

namespace HatBazar.Methods
{
    public class FooterClass : IFooter
    {
        Hat_Bazar_databaseEntities Data = new Hat_Bazar_databaseEntities();
        public string Complain(Complain complain)
        {
                Customer_Complain CC = new Customer_Complain();
                try
                {
                    Customer_Information C = Data.Customer_Information.First(x => x.User_id == complain.User_Name);

                    CC.Customer_ID = C.Customer_id;
                    CC.DateTime = DateTime.Now;
                    CC.Massage = complain.Message;

                    Data.Customer_Complain.Add(CC);

                    Data.SaveChanges();

                    //ModelState.Clear();
                    //TempData["Message"] = "Complain Submitted.";



                    try
                    {
                        System.Random rand = new System.Random((int)System.DateTime.Now.Ticks);
                        int random = rand.Next(1, 100000000);

                        string Path = @"D:\Repositories\HatBazar\Email_Document\Admin_Email\" + random + ".txt";
                        //Pass the filepath and filename to the StreamWriter Constructor

                        //StreamWriter sw = new StreamWriter(@"D:\Repositories\HatBazar\Email_Document\Admin_Email\Document.txt");
                        StreamWriter sw = new StreamWriter(Path);

                        //Write a line of text

                        sw.WriteLine(System.IO.File.ReadAllText(@"D:\Repositories\HatBazar\Email_Document\Admin_Email\Admin1.txt"));
                        sw.WriteLine(complain.Message);


                        sw.WriteLine(System.IO.File.ReadAllText(@"D:\Repositories\HatBazar\Email_Document\Admin_Email\Admin2.txt"));
                        //Write a second line of text
                        //sw.WriteLine("From the StreamWriter class");

                        //Close the file
                        sw.Close();

                       

                        try
                        {
                            //Email_ServiceController Email = new Email_ServiceController();
                            IEmail_Service Email = new Email_ServiceClass();
                            Email_Service_Model obj = new Email_Service_Model();

                            obj.ToEmail = C.Email;
                            obj.EmailSubject = "Hat Bazar";
                            obj.EMailBody = System.IO.File.ReadAllText(Path);

                            return Email.SendEmail(obj);


                        }
                        catch (Exception)
                        {

                            return "Problem while sending email, Please check details.";
                            
                        }
                        

                    }

                    catch
                    {
                        return "Path Missing to save Email.";
                    }


                }

                catch
                {
                    //ModelState.Clear();
                    return "Invalid User Name.";
                }
     
        }

      public List<Customer_Complain> ShowComplain()
        {
            try
            {
                List<Customer_Complain> C =  Data.Customer_Complain.ToList();
                return C;

            }

            catch
            {
                throw;

            }
        }

        public List<Customer_Complain> PostShowComplain(int id)
        {

            try
            {

                Customer_Complain C = Data.Customer_Complain.Single(x => x.Id == id);
                C.Status = "Done";
                Data.Entry(C).State = EntityState.Modified;
                Data.SaveChanges();
                List<Customer_Complain> Comp = Data.Customer_Complain.ToList();
                return Comp;
            }

            catch
            {
                throw;
            }
        }

        public Customer_Complain ComplainDetails(int id)
        {
            try
            {
                Customer_Complain customer_Complain = Data.Customer_Complain.Find(id);
                return customer_Complain;
            }

            catch
            {
                return null;
            }
        }

    }
}