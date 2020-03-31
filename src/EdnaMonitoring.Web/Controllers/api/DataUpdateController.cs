using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EdnaMonitoring.App.Icts.Commands.UpdateActiveIcts;
using EdnaMonitoring.App.TransLines.Commands.UpdateActiveTransLinesData;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EdnaMonitoring.Web.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataUpdateController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DataUpdateController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/DataUpdate/icts
        [HttpGet("icts")]
        public async Task<object> UpdateIctsData()
        {
            _ = await _mediator.Send(new UpdateActiveIctsDataCommand());
            return new { message = "success" };
        }

        [HttpGet("translines")]
        public async Task<object> UpdateTransLinesData()
        {
            _ = await _mediator.Send(new UpdateActiveTransLinesDataCommand());
            return new { message = "success" };
        }
    }
}