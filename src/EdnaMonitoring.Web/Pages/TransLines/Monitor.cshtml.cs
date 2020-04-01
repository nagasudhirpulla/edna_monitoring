using System.Collections.Generic;
using System.Threading.Tasks;
using EdnaMonitoring.App.TransLines.Commands.UpdateActiveTransLinesData;
using EdnaMonitoring.App.TransLines.Queries.GetAllActiveTransLines;
using EdnaMonitoring.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EdnaMonitoring.Web.Pages.TransLines
{
    public class MonitorModel : PageModel
    {
        private readonly IMediator _mediator;

        public MonitorModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IList<TransLine> TransLine { get; set; }

        public async Task OnGetAsync()
        {
            TransLine = await _mediator.Send(new GetAllActiveTransLinesQuery());
        }

        public async Task<IActionResult> OnPostAsync()
        {
            _ = await _mediator.Send(new UpdateActiveTransLinesDataCommand());
            return RedirectToPage();
        }
    }
}