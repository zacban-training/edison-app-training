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
    public class DeleteModel : PageModel
    {
        private readonly Razor_App.Data.RazorAppDbContext _context;

        public DeleteModel(Razor_App.Data.RazorAppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ApplicationUser ApplicationUser { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationuser = await _context.ApplicationUser.FirstOrDefaultAsync(m => m.Id == id);

            if (applicationuser == null)
            {
                return NotFound();
            }
            else
            {
                ApplicationUser = applicationuser;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationuser = await _context.ApplicationUser.FindAsync(id);
            if (applicationuser != null)
            {
                ApplicationUser = applicationuser;
                _context.ApplicationUser.Remove(ApplicationUser);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
