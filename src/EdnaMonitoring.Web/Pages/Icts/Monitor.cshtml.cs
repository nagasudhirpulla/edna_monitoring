using System.Collections.Generic;
using System.Threading.Tasks;
using EdnaMonitoring.App.Icts.Commands.UpdateActiveIcts;
using EdnaMonitoring.App.Icts.Queries.GetAllActiveIcts;
using EdnaMonitoring.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EdnaMonitoring.Web.Pages.Icts
{
    public class MonitorModel : PageModel
    {
        private readonly IMediator _mediator;

        public MonitorModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IList<Ict> Ict { get; set; }

        public async Task OnGetAsync()
        {
            Ict = await _mediator.Send(new GetAllActiveIctsQuery());
        }

        public async Task<IActionResult> OnPostAsync()
        {
            _ = await _mediator.Send(new UpdateActiveIctsDataCommand());
            return RedirectToPage();
        }
    }
}