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

namespace EdnaMonitoring.Web
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly EdnaMonitoring.App.Data.AppIdentityDbContext _context;

        public IndexModel(EdnaMonitoring.App.Data.AppIdentityDbContext context)
        {
            _context = context;
        }

        public IList<TransLine> TransLine { get;set; }

        public async Task OnGetAsync()
        {
            TransLine = await _context.TransLines.ToListAsync();
        }
    }
}
