﻿using EdnaMonitoring.App.Data;
using EdnaUtils;
using EdnaMonitoring.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EdnaMonitoring.App.Icts.Commands.UpdateActiveIcts
{
    public class UpdateActiveIctsDataCommand : IRequest
    {
        public class UpdateActiveIctsDataCommandHandler : IRequestHandler<UpdateActiveIctsDataCommand, Unit>
        {
            private readonly AppIdentityDbContext _context;
            private readonly AppStatus _appStatus;

            public UpdateActiveIctsDataCommandHandler(AppIdentityDbContext context, AppStatus appStatus)
            {
                _context = context;
                _appStatus = appStatus;
            }

            public async Task<Unit> Handle(UpdateActiveIctsDataCommand request, CancellationToken cancellationToken)
            {
                List<Ict> icts = await _context.Icts.Where(i => i.IsActive).ToListAsync();

                EdnaFetcher fetcher = new EdnaFetcher();
                foreach (Ict ict in icts)
                {
                    RTValue pntData = fetcher.FetchRealTimeData(ict.EdnaId);
                    if (pntData != null)
                    {
                        ict.RealValue = pntData.Dval;
                        _context.Attach(ict).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                    }
                }
                _appStatus.LastIctsUpdated = DateTime.Now;
                return Unit.Value;
            }
        }
    }
}
