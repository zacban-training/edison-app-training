using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor_App.Data;
using Razor_App.Models;

namespace Razor_App.Pages_Friends
{
    public class CreateModel : PageModel
    {
        private readonly RazorAppDbContext _context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public CreateModel(RazorAppDbContext context, UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
            _context = context;
        }

        [BindProperty]
        public string? FriendId { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // _context.ApplicationUser.Add(ApplicationUser);
            // await _context.SaveChangesAsync();
            await _context.Friendship.AddAsync(new Friendship
            {
                UserId = userManager.GetUserId(User) ?? string.Empty,
                FriendId = FriendId,
                CreatedDate = DateTime.Now
            });

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
