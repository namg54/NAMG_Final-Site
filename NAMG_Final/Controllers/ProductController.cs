using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NAMG_Final.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using NAMG_Final.Data;

namespace NAMG_Final.Controllers
{
    public class ProductController : Controller
    {
        
        private MySiteContext _context;
       

        public ProductController( MySiteContext context)
        {
            _context = context;
        }
        public IActionResult Products()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        public IActionResult Details(int id)
        {
            var products = _context.Products.Include(p => p.Item).SingleOrDefault(p => p.Id == id);
            if (products == null)
            {
                return NotFound();
            }

            var categories = _context.Products
                .Where(p => p.Id == id)
                .SelectMany(c => c.CategoryToProducts)
                .Select(c => c.Category).ToList();
            var VM = new DetailsViewModel()
            {
                Product = products,
                Categories = categories
            };
            return View(VM);
        }

        [Authorize]
        public IActionResult AddToCart(int itemid)
        {
            var product = _context.Products.Include(p => p.Item).SingleOrDefault(p => p.ItemId == itemid);
            if (product != null)
            {
                int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
                var order = _context.Orders.FirstOrDefault(o => o.UserId == userId && !o.IsFinaly);
                if (order != null)
                {
                    var orderDetail =
                        _context.OrderDetails.FirstOrDefault(d =>
                            d.OrderId == order.OrderId && d.ProductId == product.Id);
                    if (orderDetail != null)
                    {
                        orderDetail.Count += 1;
                    }
                    else
                    {
                        _context.OrderDetails.Add(new OrderDetail()
                        {
                            OrderId = order.OrderId,
                            ProductId = product.Id,
                            Price = product.Item.Price,
                            Count = 1
                        });
                    }
                }
                else
                {
                    order = new Order()
                    {
                        IsFinaly = false,
                        CreateDate = DateTime.Now,
                        UserId = userId
                    };
                    _context.Orders.Add(order);
                    _context.SaveChanges();
                    _context.OrderDetails.Add(new OrderDetail()
                    {
                        OrderId = order.OrderId,
                        ProductId = product.Id,
                        Price = product.Item.Price,
                        Count = 1
                    });
                }

                _context.SaveChanges();
            }
            return RedirectToAction("ShowCart");
        }

        [Authorize]
        public IActionResult RemoveCart(int detailId)
        {
            var orderDetail = _context.OrderDetails.Find(detailId);
            if (orderDetail?.Count<=1)
            {
                _context.Remove(orderDetail);
            }
            else
            {
                orderDetail.Count -= 1;
            }
            
            _context.SaveChanges();

            return RedirectToAction("ShowCart");
        }
        public IActionResult ShowCart()
        {
            int userid = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
            var order = _context.Orders.Where(o => o.UserId == userid && !o.IsFinaly)
                .Include(o => o.OrderDetails)
                .ThenInclude(c => c.Product)
                .FirstOrDefault();
            return View(order);
        }
        [Route("Group/{id}/{name}")]
        public IActionResult ShowProductByGroup(int id,string name)
        {
            ViewData["GroupName"] = name;
            var products = _context.CategoryToProducts
                .Where(c => c.CategoryId == id)
                .Include(c => c.Product)
                .Select(c => c.Product)
                .ToList();
            return View(products);
        }
    }
}
