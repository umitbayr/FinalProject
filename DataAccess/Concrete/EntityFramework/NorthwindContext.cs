using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;


namespace DataAccess.Concrete.EntityFramework
{
    // context : db tabloları ile proje classlarını bağlama 
    public class NorthwindContext:DbContext
    {
        // HANGİ veritabanıyla ilişki belirtilen yer
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-OJV0B7B;Database=Northwind;Trusted_Connection=True;TrustServerCertificate=True;");

        }
        public DbSet<Product> Products { get; set; }   // product nesnemi veritabanındaki product ile bağla
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
