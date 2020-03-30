using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EdnaMonitoring.App.Data;
using EdnaMonitoring.Domain.Entities;

namespace EdnaMonitoring.Web.Pages.Icts
{
    public class DeleteModel : PageModel
    {
        private readonly EdnaMonitoring.App.Data.AppIdentityDbContext _context;

        public DeleteModel(EdnaMonitoring.App.Data.AppIdentityDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Ict Ict { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ict = await _context.Icts.FirstOrDefaultAsync(m => m.Id == id);

            if (Ict == null)
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

            Ict = await _context.Icts.FindAsync(id);

            if (Ict != null)
            {
                _context.Icts.Remove(Ict);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
