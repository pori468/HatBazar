﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HatBazar.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Hat_Bazar_databaseEntities : DbContext
    {
        public Hat_Bazar_databaseEntities()
            : base("name=Hat_Bazar_databaseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Customer_Complain> Customer_Complain { get; set; }
        public virtual DbSet<Customer_Order> Customer_Order { get; set; }
        public virtual DbSet<Job_Application> Job_Application { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<Order_For_Shop> Order_For_Shop { get; set; }
        public virtual DbSet<Product_Image> Product_Image { get; set; }
        public virtual DbSet<Product_Information> Product_Information { get; set; }
        public virtual DbSet<Special_Offer> Special_Offer { get; set; }
        public virtual DbSet<Customer_Information> Customer_Information { get; set; }
        public virtual DbSet<Product_Stock> Product_Stock { get; set; }
        public virtual DbSet<UserAccount> UserAccount { get; set; }
        public virtual DbSet<Campaign> Campaign { get; set; }
        public virtual DbSet<Package> Package { get; set; }
        public virtual DbSet<Package_With_Product> Package_With_Product { get; set; }
        public virtual DbSet<Product_SellingDate> Product_SellingDate { get; set; }
        public virtual DbSet<Order_with_Date> Order_with_Date { get; set; }
        public virtual DbSet<Image> Image { get; set; }
    }
}
