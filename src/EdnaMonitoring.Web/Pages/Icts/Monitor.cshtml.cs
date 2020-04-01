using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EdnaMonitoring.App;
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
        private readonly AppStatus _appState;

        public MonitorModel(IMediator mediator, AppStatus appState)
        {
            _mediator = mediator;
            _appState = appState;
        }

        public IList<Ict> Ict { get; set; }
        public DateTime LastUpdated { get; set; }


        public async Task OnGetAsync()
        {
            Ict = await _mediator.Send(new GetAllActiveIctsQuery());
            LastUpdated = _appState.LastIctsUpdated;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            _ = await _mediator.Send(new UpdateActiveIctsDataCommand());
            return RedirectToPage();
        }
    }
}