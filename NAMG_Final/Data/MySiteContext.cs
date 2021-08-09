using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NAMG_Final.Models;

namespace NAMG_Final.Data
{
    public class MySiteContext : DbContext
    {
        public MySiteContext(DbContextOptions<MySiteContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CategoryToProduct> CategoryToProducts { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region HasKey

            modelBuilder.Entity<CategoryToProduct>().HasKey(t => new { t.ProductId, t.CategoryId });
            //modelBuilder.Entity<Product>(p =>
            //{
            //    p.HasKey(w => w.Id);
            //    p.OwnsOne<Item>(w => w.Item);
            //    p.HasOne<Item>(w => w.Item).WithOne(w => w.product)
            //        .HasForeignKey<Item>(w => w.Id);
            //});

            modelBuilder.Entity<Item>(i => { i.Property(w => w.Price).HasColumnType("Money"); });

            modelBuilder.Entity<Item>().HasData(

                new Item()
                {
                    Id = 1,
                    Price = 2540000,
                    QuantityInStock = 4
                },
                new Item()
                {
                    Id = 2,
                    Price = 2540000,
                    QuantityInStock = 5
                },
                new Item()
                {
                    Id = 3,
                    Price = 2540000,
                    QuantityInStock = 1
                }
            );


            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    ItemId = 1,
                    Name = "test1",
                    Description = "test1"
                }, new Product
                {
                    Id = 2,
                    ItemId = 2,
                    Name = "test2",
                    Description = "test2"
                }, new Product
                {
                    Id = 3,
                    ItemId = 3,
                    Name = "test3",
                    Description = "test3"
                });

            modelBuilder.Entity<CategoryToProduct>().HasData(
                new CategoryToProduct
                {
                    CategoryId = 1,
                    ProductId = 1
                },
                new CategoryToProduct
                {
                    CategoryId = 2,
                    ProductId = 2
                },
                new CategoryToProduct
                {
                    CategoryId = 3,
                    ProductId = 3
                }
            );
            #endregion
            #region sead data tbls

            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = 1,
                    Name = "Office Automations",
                    Description =
                        "اتوماسیون اداری یا Office automation نرم افزار ها یا سیستم‌های جهانی هستند که وظیفه اصلی آن‌ها ایجاد ارتباط و بهبود ارتباطات که از لحاظ تجاری از اهمیت به سزایی برخوردار است."
                }, new Category()
                {
                    Id = 2,
                    Name = "Industrial automations",
                    Description =
                        "اتوماسیون یک گام فراتر از مکانیزاسیون است، که از یک مکانیسم ماشینی خاص به کمک اپراتور انسانی برای انجام یک کار استفاده می‌کند. مکانیزاسیون عملیات دستی کار با استفاده از ماشین‌های قوی است که نیازمند تصمیم‌گیری انسانی است."
                },
                new Category()
                {
                    Id = 3,
                    Name = "All office automation subsystems",
                    Description =
                        "سیستم اتوماسیون اداری و مدیریت فرایندهای ما از یک هسته اصلی و بالغ بر ۲۰ زیرسیستم تشکیل شده است که پس از بررسی رایگان نیازمندیهای خاص کسب و کار شما، بخشی یا تمامی زیرسیستمها قابل ارائه و پیاده‌سازی است."
                }
            );

            #endregion
            base.OnModelCreating(modelBuilder);
        }
    }
}
