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
    public class DeleteModel : PageModel
    {
        private MySiteContext _context;

        public DeleteModel(MySiteContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Product Product { get; set; }
        public void OnGet(int id)
        {
            Product = _context.Products.FirstOrDefault(p => p.Id == id);
        }
        public IActionResult OnPost(int id)
        {

            var product = _context.Products.Find(Product.Id);
            var item = _context.Items.First(i => i.Id == product.ItemId);
            _context.Items.Remove(item);
            _context.Products.Remove(product);
            _context.SaveChanges();
                string filestram = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "Images",
                    "Products",
                    product.Id +".jpg" );
                if (System.IO.File.Exists(filestram))
                {
                    System.IO.File.Delete(filestram);
                }

                return RedirectToPage("Index"); 
        }

    }
}
