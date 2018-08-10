using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HatBazar.Interface;
using HatBazar.Models;
using System.IO;
using System.Web.Helpers;
using System.Data;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using HatBazar.Methods;
using HatBazar.Controllers;

namespace HatBazar.Methods

   
{
    public class CarrierClass : ICarrier
    {
        Hat_Bazar_databaseEntities Data = new Hat_Bazar_databaseEntities();
        public List <Job_Application> Index()
        {try
            {
                return Data.Job_Application.ToList(); 
            }

            catch
            {

                throw;

            }
        }


        public Job_Application Details(string id)
        {

            try
            {
                Job_Application job_Application = Data.Job_Application.Find(id);
                return job_Application;
            }
            catch
            {
                throw;
            }
        }

       public string Create(JobApplication myform)
        {

            try
            {

                Job_Application apply = new Job_Application();

                System.Random rand = new System.Random((int)System.DateTime.Now.Ticks);
                int random = rand.Next(1, 100000000);

                apply.Application_id = random.ToString();   // Auto generate hobe 

                apply.First_name = myform.First_name;
                apply.Last_name = myform.Last_name;
                apply.Address = myform.Address;
                apply.Phone = myform.Phone;
                apply.Email = myform.Email;
                apply.Gender = myform.Gender;

                apply.DateOfBirth = myform.Date + "-" + myform.Month + "-" + myform.BirthYear;

                apply.Marrage_status = myform.Marrage_status;
                apply.Last_degree = myform.Last_degree;
                apply.Year = myform.Year;
                apply.Subject = myform.Subject;
                apply.Post = myform.Post;
                apply.About = myform.About;

                Data.Job_Application.Add(apply);

                Data.SaveChanges();

                //ModelState.Clear();
                


                try
                {
                    System.Random rand1 = new System.Random((int)System.DateTime.Now.Ticks);
                    int random1 = rand1.Next(1, 100000000);

                    string Path = @"D:\Repositories\HatBazar\Email_Document\Job_Application\" + random1 + ".txt";
                    StreamWriter sw = new StreamWriter(Path);

                    //Write a line of text

                    sw.WriteLine(System.IO.File.ReadAllText(@"D:\Repositories\HatBazar\Email_Document\Job_Application\Document1.txt"));

                    sw.WriteLine("Application ID :" + apply.Application_id);
                    sw.WriteLine("First Name :" + apply.First_name);
                    sw.WriteLine("Last Name :" + apply.Last_name);
                    sw.WriteLine("Address :" + apply.Address);
                    sw.WriteLine("Phone Number :" + apply.Phone);
                    sw.WriteLine("Email :" + apply.Email);
                    sw.WriteLine("Gender :" + apply.Gender);
                    sw.WriteLine("Date of Birth :" + apply.DateOfBirth);
                    sw.WriteLine("Maritarial Status :" + apply.Marrage_status);
                    sw.WriteLine("Latest Degree :" + apply.Last_degree);
                    sw.WriteLine("Year of Passing :" + apply.Year);
                    sw.WriteLine("Subject :" + apply.Subject);
                    sw.WriteLine("Post :" + apply.Post);
                    sw.WriteLine("Resume  :" + apply.About);
                    //sw.WriteLine("all Togather :" + apply);

                    sw.WriteLine(System.IO.File.ReadAllText(@"D:\Repositories\HatBazar\Email_Document\Job_Application\Document2.txt"));
                    sw.Close();
                    try
                    {
                        //Email_ServiceController Email = new Email_ServiceController();
                        IEmail_Service Email = new Email_ServiceClass();
                            Email_Service_Model obj = new Email_Service_Model();

                        obj.ToEmail = apply.Email;
                        obj.EmailSubject = "Hat Bazar";
                        obj.EMailBody = System.IO.File.ReadAllText(Path);

                         return Email.SendEmail(obj);

                                               
                    }
                    catch (Exception)
                    {
                       
                        return  "Problem while sending email, Please check details.";
                        

                    }



                }

                catch
                {
                    return "Path Missing .";

                }


            


           

            }
            catch
            {
                return "Path Missing to save Email.";
            }
            
}

        public Job_Application GetEdit(string id)
        {

            try
            {
                Job_Application job_Application = Data.Job_Application.Find(id);
                return job_Application;

            }
            catch
            {
                return null;

            }

        }

        public string PostEdit(Job_Application job)
        {
            try
            {

                Data.Entry(job).State = EntityState.Modified;
                Data.SaveChanges();
                return "Index";
            }

            catch
            {

                throw;
            }
        }

        public Job_Application GetDelete(string job)
        {
            try
            {
                Job_Application job_Application = Data.Job_Application.Find(job);
                return job_Application;
            }
            catch
            {

                return null;
            }

        }

        public string PostDelete(string id)
        {
            try
            {
                Job_Application job_Application = Data.Job_Application.Find(id);
                Data.Job_Application.Remove(job_Application);
                Data.SaveChanges();
                return "Index";
            }

            catch
            {

                return null;
            }

        }

    }
}