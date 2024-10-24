using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Razor_App.Data;
using Razor_App.Models;

namespace Razor_App.Pages_Events
{
    public class DeleteModel : PageModel
    {
        private readonly Razor_App.Data.RazorAppDbContext _context;

        public DeleteModel(Razor_App.Data.RazorAppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UserEvent UserEvent { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userevent = await _context.UserEvent.FirstOrDefaultAsync(m => m.Id == id);

            if (userevent == null)
            {
                return NotFound();
            }
            else
            {
                UserEvent = userevent;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userevent = await _context.UserEvent.FindAsync(id);
            if (userevent != null)
            {
                UserEvent = userevent;
                _context.UserEvent.Remove(UserEvent);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
