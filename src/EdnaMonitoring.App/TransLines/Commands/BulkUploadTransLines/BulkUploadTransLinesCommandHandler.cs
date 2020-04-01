using EdnaMonitoring.App.Data;
using EdnaUtils;
using EdnaMonitoring.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EdnaMonitoring.App.Icts.Commands.BulkUploadTransLines
{
    public class BulkUploadTransLinesCommandHandler : IRequestHandler<BulkUploadTransLinesCommand, Unit>
    {
        private readonly AppIdentityDbContext _context;

        public BulkUploadTransLinesCommandHandler(AppIdentityDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(BulkUploadTransLinesCommand request, CancellationToken cancellationToken)
        {
            // get lines
            List<string> lines = request.UploadString.Split('\n').ToList();
            // each line should have Lines data in the format name, EdnaId, voltageLevel
            foreach (string line in lines)
            {
                List<string> segments = line.Split(',').Select(e => e.Trim()).ToList();
                if (segments.Count != 4) { continue; }
                string name = segments[0];
                string EdnaId = segments[1];
                int voltLevel = int.Parse(segments[2]);
                _context.TransLines.Add(new TransLine() { Name = name, EdnaId = EdnaId, Voltage = voltLevel });
            }
            // save real time data to db
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
