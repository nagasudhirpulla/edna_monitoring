using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EdnaMonitoring.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EdnaMonitoring.Web.Pages.Icts
{
    public class MonitorModel : PageModel
    {
        public IList<Ict> Ict { get; set; }

        public void OnGet()
        {

        }
    }
}