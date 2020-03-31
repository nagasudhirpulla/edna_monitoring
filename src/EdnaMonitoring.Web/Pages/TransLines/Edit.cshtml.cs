using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EdnaMonitoring.App.Data;
using EdnaMonitoring.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using EdnaMonitoring.App.Security;

namespace EdnaMonitoring.Web
{
    [Authorize(Roles = SecurityConstants.AdminRoleString)]
    public class EditModel : PageModel
    {
        private readonly EdnaMonitoring.App.Data.AppIdentityDbContext _context;

        public EditModel(EdnaMonitoring.App.Data.AppIdentityDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TransLine TransLine { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TransLine = await _context.TransLines.FirstOrDefaultAsync(m => m.Id == id);

            if (TransLine == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TransLine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransLineExists(TransLine.Id))
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

        private bool TransLineExists(int id)
        {
            return _context.TransLines.Any(e => e.Id == id);
        }
    }
}
