using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HatBazar.Models;
using System.Data.Entity;
using HatBazar.Interface;


namespace HatBazar.Methods


{
    public class Product_InformationClass : IProduct_Information
    {
        Hat_Bazar_databaseEntities Data = new Hat_Bazar_databaseEntities();
        public List<Product_Information> Index(string option, string search, int? Type)
        {
            try
            {
              
                
                if (option == null && search == null && Type != null)
                {
                    return Data.Product_Information.Where(x => x.Special_Offer == Type).ToList();

                }
                else if (option == "Product_name" && search != null)
                {
                    return Data.Product_Information.Include(p => p.Image).Where(x => x.Product_name.StartsWith(search) || search == null).ToList();

                }
                else if (option == "Tag" && search != null)
                {
                    return Data.Product_Information.Include(p => p.Image).Where(x => x.Tag.StartsWith(search) || search == null).ToList();

                }
                else if (option == null && search != null)
                {
                    return Data.Product_Information.Include(p => p.Image).Where(x => x.Product_name.StartsWith(search) || search == null).ToList();

                }
                else
                {
                    return Data.Product_Information.ToList();
                }


            }


            catch
            {
                throw;

            }


        }

        public ProductModel Details(int id)
        {
            {
                try
                {
                    
                    Product_Information product_Information = Data.Product_Information.Find(id);
                    Image PI = Data.Image.Find(id);
                    Product_Stock PS = Data.Product_Stock.Find(id);
                    Category C = Data.Category.Single(x => x.Id == product_Information.Category_id);
                    
                        ProductModel p = new ProductModel();
                        p.product_id = id;
                        p.Product_name = product_Information.Product_name;
                        p.Unit = product_Information.Unit;
                        p.price_per_unit = product_Information.Price_per_unit;
                        p.tag = product_Information.Tag;

                        p.Image = PI.Image1;
                        p.stock = PS.Stock_unit;
                        p.catagory = C.Parent_id.Value;

                        return p;
                    

                }
                catch
                {

                    throw;
                }
            }


            return null;

        }

        public string Create(ProductModel product_Information)
        {
            try
            {
                Product_Information P = new Product_Information();
                P.Product_name = product_Information.Product_name;
                P.Unit = product_Information.Unit;
                P.Price_per_unit = product_Information.price_per_unit;
                P.Tag = product_Information.tag;
                P.Special_Offer = 0;
                P.Category_id = product_Information.catagory;

                Data.Product_Information.Add(P);
                Data.SaveChanges();

                
                Image image = new Image { ID = P.Product_id, Image1 = product_Information.Image };

                Data.Image.Add(image);
                Data.SaveChanges(); 
                
                

                Product_Stock PS = new Product_Stock { Product_id = P.Product_id, Stock_unit = product_Information.stock,
                    Product_Name= product_Information.Product_name           };

                
                Data.Product_Stock.Add(PS);
                Data.SaveChanges();

                Category C = new Category();
                C.Id = product_Information.product_id;
                C.Name = product_Information.Product_name;
                C.Parent_id = product_Information.catagory;
                Data.Category.Add(C);
                Data.SaveChanges();


                return "Index";
            }
            catch
            {
                throw;
            }
           
        }


        public string Addtocart(int? id, string Customerid)
        {

            if (id != null)
            {
                try
                {
                    Product_Information product_Information = new Product_Information();
                    product_Information = Data.Product_Information.Single(x => x.Product_id == id);
                    bool Check = Data.Customer_Order.Any(x => x.Product_id == product_Information.Product_id && x.Purches_id == Customerid && x.Order_Status == 1);
                    if (Check == true)
                    {
                        Customer_Order Data_Amdani = Data.Customer_Order.Single(x => x.Product_id == product_Information.Product_id && x.Purches_id == Customerid && x.Order_Status == 1);

                        Data_Amdani.Unit_number++;
                        Data.Entry(Data_Amdani).State = EntityState.Modified;
                    }
                    else
                    {

                        Customer_Order CO = new Customer_Order();
                        CO.Product_Name = product_Information.Product_name;
                        CO.Unit_name = product_Information.Unit;
                        CO.Unit_number = 1;
                        CO.Price = product_Information.Price_per_unit;
                        CO.Product_id = product_Information.Product_id;
                        CO.Purches_id = Customerid;
                        CO.Order_Status = 1;

                        Data.Customer_Order.Add(CO);
                    }

                    Data.SaveChanges();


                    return product_Information.Product_name + "" + " Added Successfully.";

                }


                catch
                {
                    throw;
                }


            }
            else
            {
                return "Product could not be Added.";
            }


        }

        public ProductModel GetEdit(int id)
        {

            try
            {
                Product_Information product_Information = Data.Product_Information.Find(id);
                Image PI = Data.Image.Find(id);
                Product_Stock PS = Data.Product_Stock.Find(id);
                Category C = Data.Category.Single(x => x.Name == product_Information.Product_name);

                ProductModel p = new ProductModel();
                p.product_id = id;
                p.Product_name = product_Information.Product_name;
                p.Unit = product_Information.Unit;
                p.price_per_unit = product_Information.Price_per_unit;
                p.tag = product_Information.Tag;

                p.Image = PI.Image1;
                p.stock = PS.Stock_unit;
                p.catagory = C.Parent_id.Value;

                return p;

            }

            catch
            {

                throw;

            }
        }

       public string PostEdit(ProductModel product_Information)
        {


            try
            {

                Product_Information P = Data.Product_Information.Find(product_Information.product_id);
                Image PI = Data.Image.Find(product_Information.product_id);
                Product_Stock PS = Data.Product_Stock.Find(product_Information.product_id);
                Category C = Data.Category.Single(x => x.Name == product_Information.Product_name);


                P.Product_name = product_Information.Product_name;
                P.Unit = product_Information.Unit;
                P.Price_per_unit = product_Information.price_per_unit;
                P.Tag = product_Information.tag;
                P.Special_Offer = 0;
                P.Category_id = product_Information.catagory;

                Data.Entry(P).State = EntityState.Modified;


                PI.Image1 = product_Information.Image;
                Data.Entry(PI).State = EntityState.Modified;


                
                PS.Product_Name = product_Information.Product_name;
                PS.Stock_unit = product_Information.stock;
                Data.Entry(PS).State = EntityState.Modified;


                
                C.Name = product_Information.Product_name;
                C.Parent_id = product_Information.catagory;
                Data.Entry(C).State = EntityState.Modified;


                Data.SaveChanges();


                return "Index";
            }
            catch
            {
                throw;
            }
        }

        public ProductModel GetDelete(int id)
        {

            try
            {
                Product_Information product_Information = Data.Product_Information.Find(id);
                Image PI = Data.Image.Find(id);
                Product_Stock PS = Data.Product_Stock.Find(id);
                Category C = Data.Category.Single(x => x.Name == product_Information.Product_name);

                ProductModel p = new ProductModel();
                p.product_id = id;
                p.Product_name = product_Information.Product_name;
                p.Unit = product_Information.Unit;
                p.price_per_unit = product_Information.Price_per_unit;
                p.tag = product_Information.Tag;

                p.Image = PI.Image1;
                p.stock = PS.Stock_unit;
                p.catagory = C.Parent_id.Value;

                return p;

            }

            catch
            {

                throw;

            }

        }

        public string PostDelete(int id)
        {

            try
            {
                Product_Information product_Information = Data.Product_Information.Find(id);

                Category C = Data.Category.Single(x => x.Parent_id == product_Information.Category_id);
                Data.Category.Remove(C);

                              
                Image PI = Data.Image.Find(id);
                Data.Image.Remove(PI);
                
                Product_Stock PS = Data.Product_Stock.Find(id);
                Data.Product_Stock.Remove(PS);

                
                Data.Product_Information.Remove(product_Information);


                Data.SaveChanges();
                return "Index";
            }

            catch
            {
                throw;
            }
        }


        public List<Product_Information> Status(int id)
        {
            try
            {
                List<Product_Information> PP = new List<Product_Information>();
                Product_Information P = Data.Product_Information.Single(x=>x.Product_id==id);
                if (P.Special_Offer == 1)
                {
                    P.Special_Offer = 0;
                    Data.Entry(P).State = EntityState.Modified;
                    Data.SaveChanges();
                    PP = Data.Product_Information.Where(x => x.Special_Offer == 1).ToList();
                }
                else
                { P.Special_Offer = 1;
                    Data.Entry(P).State = EntityState.Modified;
                    Data.SaveChanges();
                    PP =Data.Product_Information.Where(x => x.Special_Offer == 0).ToList();
                }
               
                return PP;

            }

            catch
            {
                throw;

            }
        }
    }
    }
