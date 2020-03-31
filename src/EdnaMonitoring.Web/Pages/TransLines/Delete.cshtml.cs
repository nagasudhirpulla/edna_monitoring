using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EdnaMonitoring.App.Data;
using EdnaMonitoring.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using EdnaMonitoring.App.Security;

namespace EdnaMonitoring.Web
{
    [Authorize(Roles = SecurityConstants.AdminRoleString)]
    public class DeleteModel : PageModel
    {
        private readonly EdnaMonitoring.App.Data.AppIdentityDbContext _context;

        public DeleteModel(EdnaMonitoring.App.Data.AppIdentityDbContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TransLine = await _context.TransLines.FindAsync(id);

            if (TransLine != null)
            {
                _context.TransLines.Remove(TransLine);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
