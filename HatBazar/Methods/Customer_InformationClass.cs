using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HatBazar.Interface;
using HatBazar.Models;
using System.Data.Entity;

namespace HatBazar.Methods
{
    public class Customer_InformationClass :ICustomer_Information
    {
        Hat_Bazar_databaseEntities Data = new Hat_Bazar_databaseEntities();

        public List<Customer_Information> Index()
        { 
            try
            {
               List<Customer_Information> customer_Information = Data.Customer_Information.ToList();
                return customer_Information;
            }
            catch
            {
                throw;

            }

        }


        public Customer_Information Details(int? id)
        {
            try
            {
                Customer_Information customer_Information = Data.Customer_Information.Find(id);
                return customer_Information;
            }
            catch
            {
                throw;

            }

        }

       public Customer_Information GetDelete(int? id)
        {
            try
            {
                Customer_Information customer_Information = Data.Customer_Information.Find(id);
                return customer_Information;
            }
            catch
            {
                throw;

            }

        }

        public string PostDelete(int? id)
        {
            try
            {
                Customer_Information customer_Information = Data.Customer_Information.Find(id);
                Data.Customer_Information.Remove(customer_Information);
                Data.SaveChanges();
                return "Index";
            }
            catch
            {
                throw;

            }

        }

        public string Register(MyUserAccount account)
        {


            try
            {
                Customer_Information a = new Customer_Information();
                a.Name = account.Name;
                a.Address = account.Address;
                a.Phone = int.Parse(account.Phone);
                a.Email = account.Email;
                a.Type = account.Type;
                a.User_id = account.UserName;
                a.Password = account.Password;


                Data.Customer_Information.Add(a);

                Data.SaveChanges();
                return account.Name + " " + " is Successfully Registered";

            }

            catch
            {
                return account.Name + " " + " is Not Registered. Try Again ";

            }

        }

        public Customer_Information GetMyPage(int CustomerId)
        {

            Customer_Information c = Data.Customer_Information.Single(x => x.Customer_id == CustomerId);
            return c;
        }

        public string PostMyPage(Customer_Information MyInfo)
        {
            if (MyInfo != null)
            {
                try
                {

                    Customer_Information a = Data.Customer_Information.Single(x => x.Customer_id == MyInfo.Customer_id);

                    a.Name = MyInfo.Name;
                    a.Address = MyInfo.Address;
                    a.Phone = MyInfo.Phone;
                    a.Email = MyInfo.Email;
                    a.Type = MyInfo.Type;
                    a.User_id = MyInfo.User_id;
                    a.Password = MyInfo.Password;

                    Data.Entry(a).State = EntityState.Modified;


                    return "Informations are Updated Successfully.";
                }

                catch

                {
                    return "Informations are  Not Updated. Please Try Later";
                }
            }

            else
            {

                return "Informations are  Not Updated. Please Try Later";
            }
        }
    }
}