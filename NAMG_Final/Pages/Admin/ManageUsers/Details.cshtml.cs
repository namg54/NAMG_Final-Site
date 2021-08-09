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
    public class DetailsModel : PageModel
    {
        private readonly NAMG_Final.Data.MySiteContext _context;

        public DetailsModel(NAMG_Final.Data.MySiteContext context)
        {
            _context = context;
        }

        public Users Users { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Users = await _context.Users.FirstOrDefaultAsync(m => m.UserId == id);

            if (Users == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
