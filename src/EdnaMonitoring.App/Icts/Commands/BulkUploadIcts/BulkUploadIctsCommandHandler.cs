using EdnaMonitoring.App.Data;
using EdnaUtils;
using EdnaMonitoring.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EdnaMonitoring.App.Icts.Commands.BulkUploadIcts
{
    public class BulkUploadIctsCommandHandler : IRequestHandler<BulkUploadIctsCommand, Unit>
    {
        private readonly AppIdentityDbContext _context;

        public BulkUploadIctsCommandHandler(AppIdentityDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(BulkUploadIctsCommand request, CancellationToken cancellationToken)
        {
            // get lines
            List<string> lines = request.UploadString.Split('\n').ToList();
            // each line should have ICT data in the format name, EdnaId, hvVoltage, lvVoltage
            foreach (string line in lines)
            {
                List<string> segments = line.Split(',').Select(e => e.Trim()).ToList();
                if (segments.Count != 4) { continue; }
                string name = segments[0];
                string EdnaId = segments[1];
                int hvLevel = int.Parse(segments[2]);
                int lvLevel = int.Parse(segments[3]);
                _context.Icts.Add(new Ict() { Name = name, EdnaId = EdnaId, HVoltage = hvLevel, LVoltage = lvLevel });
            }
            // save real time data to db
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
