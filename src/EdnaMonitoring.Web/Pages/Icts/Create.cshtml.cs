using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EdnaMonitoring.App.Data;
using EdnaMonitoring.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using EdnaMonitoring.App.Security;

namespace EdnaMonitoring.Web.Pages.Icts
{
    [Authorize(Roles = SecurityConstants.AdminRoleString)]
    public class CreateModel : PageModel
    {
        private readonly EdnaMonitoring.App.Data.AppIdentityDbContext _context;

        public CreateModel(EdnaMonitoring.App.Data.AppIdentityDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Ict Ict { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Icts.Add(Ict);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
