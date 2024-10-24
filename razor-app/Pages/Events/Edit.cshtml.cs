using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Razor_App.Data;
using Razor_App.Models;

namespace Razor_App.Pages_Events
{
    public class EditModel : PageModel
    {
        private readonly Razor_App.Data.RazorAppDbContext _context;

        public EditModel(Razor_App.Data.RazorAppDbContext context)
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

            var userevent =  await _context.UserEvent.FirstOrDefaultAsync(m => m.Id == id);
            if (userevent == null)
            {
                return NotFound();
            }
            UserEvent = userevent;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(UserEvent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserEventExists(UserEvent.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool UserEventExists(int id)
        {
            return _context.UserEvent.Any(e => e.Id == id);
        }
    }
}
