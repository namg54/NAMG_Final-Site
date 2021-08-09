using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NAMG_Final.Data;
using NAMG_Final.Models;

namespace NAMG_Final.Pages.Admin.ManageUsers
{
    public class IndexModel : PageModel
    {
        private readonly NAMG_Final.Data.MySiteContext _context;

        public IndexModel(NAMG_Final.Data.MySiteContext context)
        {
            _context = context;
        }

        public IList<Users> Users { get;set; }

        public async Task OnGetAsync()
        {
            Users = await _context.Users.ToListAsync();
        }
    }
}
