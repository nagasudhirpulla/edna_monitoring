using System.Threading.Tasks;
using EdnaMonitoring.App.Icts.Commands.BulkUploadTransLines;
using EdnaMonitoring.App.Security;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EdnaMonitoring.Web.Pages.TransLines
{
    [Authorize(Roles = SecurityConstants.AdminRoleString)]
    public class BulkUploadModel : PageModel
    {
        private readonly IMediator _mediator;

        public BulkUploadModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        [BindProperty]
        public string UploadString { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _ = await _mediator.Send(new BulkUploadTransLinesCommand() { UploadString = UploadString.Replace('\r', ' ') });

            return RedirectToPage("./Index");
        }
    }
}