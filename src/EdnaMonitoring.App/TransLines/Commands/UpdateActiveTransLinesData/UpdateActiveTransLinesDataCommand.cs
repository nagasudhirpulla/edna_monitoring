﻿using EdnaMonitoring.App.Data;
using EdnaMonitoring.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EdnaUtils;

namespace EdnaMonitoring.App.TransLines.Commands.UpdateActiveTransLinesData
{
    public class UpdateActiveTransLinesDataCommand : IRequest
    {
        public class UpdateActiveTransLinesDataCommandHandler : IRequestHandler<UpdateActiveTransLinesDataCommand, Unit>
        {
            private readonly AppIdentityDbContext _context;
            private readonly AppStatus _appStatus;

            public UpdateActiveTransLinesDataCommandHandler(AppIdentityDbContext context, AppStatus appStatus)
            {
                _context = context;
                _appStatus = appStatus;
            }

            public async Task<Unit> Handle(UpdateActiveTransLinesDataCommand request, CancellationToken cancellationToken)
            {
                List<TransLine> tLines = await _context.TransLines.Where(tl => tl.IsActive).ToListAsync();

                EdnaFetcher fetcher = new EdnaFetcher();
                foreach (TransLine tLine in tLines)
                {
                    RTValue pntData = fetcher.FetchRealTimeData(tLine.EdnaId);
                    if (pntData != null)
                    {
                        tLine.RealValue = pntData.Dval;
                        _context.Attach(tLine).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                    }
                }
                _appStatus.LastTransLinesUpdated = DateTime.Now;
                return Unit.Value;
            }
        }
    }
}
