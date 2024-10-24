using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Razor_App.Data;
using Razor_App.Models;

namespace Razor_App.Pages_Events
{
    public class CreateModel : PageModel
    {
        private readonly Razor_App.Data.RazorAppDbContext _context;

        public CreateModel(Razor_App.Data.RazorAppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public UserEvent UserEvent { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.UserEvent.Add(UserEvent);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
