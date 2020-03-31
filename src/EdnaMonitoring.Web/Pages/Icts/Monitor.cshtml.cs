using System.Collections.Generic;
using System.Threading.Tasks;
using EdnaMonitoring.App.Icts.Queries.GetAllActiveIcts;
using EdnaMonitoring.Domain.Entities;
using MediatR;
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
    }
}