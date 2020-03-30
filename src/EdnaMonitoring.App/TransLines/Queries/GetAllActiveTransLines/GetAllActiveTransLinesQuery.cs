using EdnaMonitoring.App.Data;
using EdnaMonitoring.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EdnaMonitoring.App.TransLines.Queries.GetAllActiveTransLines
{
    public class GetAllActiveTransLinesQuery : IRequest<List<TransLine>>
    {
        public class GetAllActiveTransLinesQueryHandler : IRequestHandler<GetAllActiveTransLinesQuery, List<TransLine>>
        {
            private readonly AppIdentityDbContext _context;

            public GetAllActiveTransLinesQueryHandler(AppIdentityDbContext context)
            {
                _context = context;
            }

            public async Task<List<TransLine>> Handle(GetAllActiveTransLinesQuery request, CancellationToken cancellationToken)
            {
                List<TransLine> res = await _context.TransLines.Where(t => t.IsActive).ToListAsync();
                return res;
            }
        }
    }
}
