using EdnaMonitoring.App.Data;
using EdnaMonitoring.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EdnaMonitoring.App.Icts.Queries.GetAllActiveIcts
{
    public class GetAllActiveIctsQuery : IRequest<List<Ict>>
    {
        public class GetAllActiveIctsQueryHandler : IRequestHandler<GetAllActiveIctsQuery, List<Ict>>
        {
            private readonly AppIdentityDbContext _context;

            public GetAllActiveIctsQueryHandler(AppIdentityDbContext context)
            {
                _context = context;
            }

            public async Task<List<Ict>> Handle(GetAllActiveIctsQuery request, CancellationToken cancellationToken)
            {
                List<Ict> res = await _context.Icts.ToListAsync();
                return res;
            }
        }
    }
}
