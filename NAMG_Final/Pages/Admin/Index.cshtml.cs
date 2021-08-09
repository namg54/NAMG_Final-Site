using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NAMG_Final.Data;
using NAMG_Final.Models;

namespace NAMG_Final.Pages.Admin
{
    public class IndexModel : PageModel
    {
        private MySiteContext _context;

        public IndexModel(MySiteContext context)
        {
            _context = context;
        }
        public IEnumerable<Product> Products { get; set; }

        public void OnGet()
        {
            Products = _context.Products.Include(p=>p.Item);
        }
        public void OnPost()
        {
        }
    }
}
