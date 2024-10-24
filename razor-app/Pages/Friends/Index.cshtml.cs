using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Razor_App.Data;
using Razor_App.Models;

namespace Razor_App.Pages_Friends
{
    public class IndexModel : PageModel
    {
        private readonly Razor_App.Data.RazorAppDbContext _context;

        public IndexModel(Razor_App.Data.RazorAppDbContext context)
        {
            _context = context;
        }

        public IList<ApplicationUser> ApplicationUser { get;set; } = default!;

        public async Task OnGetAsync()
        {
            ApplicationUser = await _context.ApplicationUser.ToListAsync();
        }
    }
}
