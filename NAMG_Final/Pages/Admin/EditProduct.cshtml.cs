using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NAMG_Final.Data;
using NAMG_Final.Models;

namespace NAMG_Final.Pages.Admin
{
    public class EditProductModel : PageModel
    {
        private MySiteContext _context;

        public EditProductModel(MySiteContext Context)
        {
            _context = Context;
        }

        [BindProperty]
        public AddEditProductViewModel Product { get; set; }


        [BindProperty]
        public List<int> selectedGroups { get; set; }

        public List<int> GroupsProduct { get; set; }
        public void OnGet(int id)
        {
            Product = _context.Products.Include(p=>p.Item)
                .Where(p => p.Id == id)
                .Select(s=>new AddEditProductViewModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                    Description = s.Description,
                    Price = s.Item.Price,
                    QuantityInStock = s.Item.QuantityInStock
                }).FirstOrDefault();

            Product.Categories = _context.Categories.ToList();
            GroupsProduct = _context.CategoryToProducts.Where(c => c.ProductId == id).Select(g => g.CategoryId)
                .ToList();

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            
                return Page();


            var product = _context.Products.Find(Product.Id);
            var item = _context.Items.First(i => i.Id == product.ItemId);
            product.Name = Product.Name;
            product.Description = Product.Description;
            item.Price = Product.Price;
            item.QuantityInStock = Product.QuantityInStock;
            _context.SaveChanges();
            if (Product.Picture?.Length > 0)
            {
                string filestram = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "Images",
                    "Products",
                    product.Id + Path.GetExtension(Product.Picture.FileName));
                using (var stram = new FileStream(filestram, FileMode.Create))
                {
                    Product.Picture.CopyTo(stram);
                }
            }

            _context.CategoryToProducts.Where(c => c.ProductId == Product.Id).ToList()
                .ForEach(g => _context.CategoryToProducts.Remove(g));

            if (selectedGroups.Any() && selectedGroups.Count > 0)
            {
                foreach (int gr in selectedGroups)
                {
                    _context.CategoryToProducts.Add(new CategoryToProduct()
                    {
                        CategoryId = gr,
                        ProductId = Product.Id
                    });
                }

                _context.SaveChanges();
            }

            return RedirectToPage("Index");
        }
    }
}
